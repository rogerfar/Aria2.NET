using Newtonsoft.Json;

namespace Aria2NET;

public class UriResult
{
    /// <summary>
    ///     'used' if the URI is in use. 'waiting' if the URI is still waiting in the queue.
    /// </summary>
    [JsonProperty("status")]
    public String Status { get; set; } = null!;

    /// <summary>
    ///     URI
    /// </summary>
    [JsonProperty("uri")]
    public String Uri { get; set; } = null!;
}