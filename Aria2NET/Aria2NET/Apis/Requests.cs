using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aria2NET.Exceptions;
using Newtonsoft.Json;

namespace Aria2NET.Apis
{
    internal class Requests
    {
        private readonly HttpClient _httpClient;
        private readonly Store _store;

        public Requests(HttpClient httpClient, Store store)
        {
            _httpClient = httpClient;
            _store = store;
        }

        private async Task<String> Request(String method, CancellationToken cancellationToken, params Object[] parameters)
        {
            var requestUrl = $"{_store.Aria2Url}";

            var request = new Request
            {
                Id = "aria2net",
                Jsonrpc = "2.0",
                Method = method,
                Parameters = new List<Object>()
            };

            if (!String.IsNullOrWhiteSpace(_store.Secret))
            {
                request.Parameters.Add($"token:{_store.Secret}");
            }
                
            if (parameters != null && parameters.Length > 0)
            {
                foreach (var parameter in parameters.Where(m => m != null))
                {
                    request.Parameters.Add(parameter);
                }
            }

            var jsonRequest = JsonConvert.SerializeObject(request);

            var content = new StringContent(jsonRequest);

            var response = await _httpClient.PostAsync(requestUrl, content, cancellationToken);

            var buffer = await response.Content.ReadAsByteArrayAsync();
            var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                text = null;
            }

            if (!response.IsSuccessStatusCode)
            {
                var aria2Exception = ParseAria2Exception(text);

                if (aria2Exception != null)
                {
                    throw aria2Exception;
                }

                throw new Exception(text);
            }

            return text;
        }
        
        private async Task<T> Request<T>(String url, CancellationToken cancellationToken, params Object[] parameters)
            where T : class, new()
        {
            var result = await Request(url, cancellationToken, parameters);

            if (result == null)
            {
                return new T();
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (JsonSerializationException ex)
            {
                throw new JsonSerializationException($"Unable to deserialize Aria2 API response to {typeof(T).Name}. Response was: {result}", ex);
            }
        }
        
        public async Task<String> GetRequestAsync(String url, CancellationToken cancellationToken)
        {
            return await Request(url, cancellationToken);
        }

        public async Task<String> GetRequestAsync(String url, CancellationToken cancellationToken, params Object[] parameters)
        {
            return await Request(url, cancellationToken, parameters);
        }

        public async Task<T> GetRequestAsync<T>(String url, CancellationToken cancellationToken)
        {
            var aria2Result = await Request<RequestResult<T>>(url, cancellationToken);

            return aria2Result.Result;
        }

        public async Task<T> GetRequestAsync<T>(String url, CancellationToken cancellationToken, params Object[] parameters)
        {
            var aria2Result = await Request<RequestResult<T>>(url, cancellationToken, parameters);

            return aria2Result.Result;
        }
        
        private static Aria2Exception ParseAria2Exception(String text)
        {
            try
            {
                var requestError = JsonConvert.DeserializeObject<RequestResult<RequestError>>(text);

                if (requestError != null)
                {
                    return new Aria2Exception(requestError.Error.Code, requestError.Error.Message);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
