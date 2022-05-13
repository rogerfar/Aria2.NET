using Newtonsoft.Json;

namespace Aria2NET;

public class SessionResult
{
    [JsonProperty("sessionId")]
    public String SessionId { get; set; } = null!;
}