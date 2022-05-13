using Newtonsoft.Json;

namespace Aria2NET;

public class PeerResult
{
    /// <summary>
    ///     true if aria2 is choking the peer. Otherwise false.
    /// </summary>
    [JsonProperty("amChoking")]
    public Boolean AmChoking { get; set; }

    /// <summary>
    ///     Hexadecimal representation of the download progress of the peer. The highest bit corresponds to the piece at index
    ///     0. Set bits indicate the piece is available and unset bits indicate the piece is missing. Any spare bits at the end
    ///     are set to zero.
    /// </summary>
    [JsonProperty("bitfield")]
    public String Bitfield { get; set; } = null!;

    /// <summary>
    ///     Download speed (byte/sec) that this client obtains from the peer.
    /// </summary>
    [JsonProperty("downloadSpeed")]
    public Decimal DownloadSpeed { get; set; }

    /// <summary>
    ///     IP address of the peer.
    /// </summary>
    [JsonProperty("ip")]
    public String Ip { get; set; } = null!;

    /// <summary>
    ///     true if the peer is choking aria2. Otherwise false.
    /// </summary>
    [JsonProperty("peerChoking")]
    public Boolean PeerChoking { get; set; }

    /// <summary>
    ///     Percent-encoded peer ID.
    /// </summary>
    [JsonProperty("peerId")]
    public String PeerId { get; set; } = null!;

    /// <summary>
    ///     Port number of the peer.
    /// </summary>
    [JsonProperty("port")]
    public Int32 Port { get; set; }

    /// <summary>
    ///     true if this peer is a seeder. Otherwise false.
    /// </summary>
    [JsonProperty("seeder")]
    public Boolean Seeder { get; set; }

    /// <summary>
    ///     Upload speed(byte/sec) that this client uploads to the peer.
    /// </summary>
    [JsonProperty("uploadSpeed")]
    public Decimal UploadSpeed { get; set; }
}