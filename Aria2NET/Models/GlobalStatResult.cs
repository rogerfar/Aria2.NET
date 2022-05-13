using Newtonsoft.Json;

namespace Aria2NET;

public class GlobalStatResult
{
    [JsonProperty("downloadSpeed")]
    public Decimal DownloadSpeed { get; set; }

    [JsonProperty("numActive")]
    public Int32 NumActive { get; set; }

    [JsonProperty("numStopped")]
    public Int32 NumStopped { get; set; }

    [JsonProperty("numStoppedTotal")]
    public Int32 NumStoppedTotal { get; set; }

    [JsonProperty("numWaiting")]
    public Int32 NumWaiting { get; set; }

    [JsonProperty("uploadSpeed")]
    public Decimal UploadSpeed { get; set; }
}