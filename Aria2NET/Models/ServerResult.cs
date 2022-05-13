using Newtonsoft.Json;

namespace Aria2NET;

public class ServerResult
{
    [JsonProperty("index")]
    public String Index { get; set; } = null!;

    [JsonProperty("servers")]
    public List<ServerResultServer> Servers { get; set; } = new List<ServerResultServer>();
}

public class ServerResultServer
{
    [JsonProperty("currentUri")]
    public String CurrentUri { get; set; } = null!;

    [JsonProperty("downloadSpeed")]
    public Decimal DownloadSpeed { get; set; }

    [JsonProperty("uri")]
    public String Uri { get; set; } = null!;
}