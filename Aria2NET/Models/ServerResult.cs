using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aria2NET;

public class ServerResult
{
    [JsonProperty("index")]
    public String Index { get; set; }

    [JsonProperty("servers")]
    public List<ServerResultServer> Servers { get; set; }
}

public class ServerResultServer
{
    [JsonProperty("currentUri")]
    public String CurrentUri { get; set; }

    [JsonProperty("downloadSpeed")]
    public Decimal DownloadSpeed { get; set; }

    [JsonProperty("uri")]
    public String Uri { get; set; }
}