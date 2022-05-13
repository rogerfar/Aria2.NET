using Newtonsoft.Json;

namespace Aria2NET;

public class Request
{
    [JsonProperty("id")]
    public String Id { get; set; } = null!;

    [JsonProperty("jsonrpc")]
    public String Jsonrpc { get; set; } = null!;

    [JsonProperty("method")]
    public String Method { get; set; } = null!;

    [JsonProperty("params")]
    public IList<Object?>? Parameters { get; set; }
}

public class MulticallRequest
{
    [JsonProperty("methodName")]
    public String MethodName { get; set; } = null!;

    [JsonProperty("params")]
    public IList<Object> Parameters { get; set; } = new List<Object>();
}