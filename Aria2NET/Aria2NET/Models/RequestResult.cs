using System;
using Newtonsoft.Json;

namespace Aria2NET;

public class RequestResult<T>
{
    [JsonProperty("id")]
    public String Id { get; set; }

    [JsonProperty("jsonrpc")]
    public String Jsonrpc { get; set; }

    [JsonProperty("result")]
    public T Result { get; set; }

    [JsonProperty("error")]
    public RequestError Error { get; set; }
}