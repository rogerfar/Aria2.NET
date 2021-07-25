using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aria2NET.Apis;

namespace Aria2NET
{
    /// <summary>
    ///     Documentation about the API can be found here:
    ///     https://aria2.github.io/manual/en/html/aria2c.html#json-rpc-using-http-get
    /// </summary>
    public class Aria2NetClient
    {
        private readonly Requests _requests;

        /// <summary>
        ///     Initialize the Aria2NetClient API.
        /// </summary>
        /// <param name="aria2Url">
        ///     The URL to your aria2 instance. Must end in /jsonrpc, for example: http://127.0.0.1:6801/jsonrpc.
        ///     To use SSL, use https.
        /// </param>
        /// <param name="httpClient">
        ///     Optional HttpClient if you want to use your own HttpClient.
        /// </param>
        public Aria2NetClient(String aria2Url, HttpClient httpClient = null)
        {
            if (!aria2Url.EndsWith("/jsonrpc"))
            {
                throw new Exception($"The URL must end with /jsonrpc");
            }

            var store = new Store
            {
                Aria2Url = aria2Url
            };

            var client = httpClient ?? new HttpClient();

            _requests = new Requests(client, store);
        }

        /// <summary>
        ///     This method adds a new download.
        /// </summary>
        /// <param name="uriList">
        ///     UriList is a list of HTTP/FTP/SFTP/BitTorrent URIs (strings) pointing to the same resource. If you mix URIs
        ///     pointing to different resources, then the download may fail or be corrupted without aria2 complaining. When adding
        ///     BitTorrent Magnet URIs, uris must have only one element and it should be BitTorrent Magnet URI.
        /// </param>
        /// <param name="options">
        ///     For all available options see: https://aria2.github.io/manual/en/html/aria2c.html#id2
        /// </param>
        /// <param name="position">
        ///     If position is given, it must be an integer starting from 0. The new download will be inserted at position in the
        ///     waiting queue. If position is omitted or position is larger than the current size of the queue, the new download is
        ///     appended to the end of the queue.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of the newly registered download</returns>
        public async Task<String> AddUri(IList<String> uriList, IDictionary<String, Object> options = null, Int32? position = null, CancellationToken cancellationToken = default)
        {
            if (uriList == null || uriList.Count == 0)
            {
                throw new ArgumentException("UriList cannot be null or empty");
            }

            return await _requests.GetRequestAsync("aria2.addUri", cancellationToken, uriList, options, position);
        }
    }
}
