using Newtonsoft.Json;

namespace Aria2NET;

public class DownloadStatusResult
{
    /// <summary>
    ///     Hexadecimal representation of the download progress. The highest bit corresponds to the piece at index 0. Any set
    ///     bits indicate loaded pieces, while unset bits indicate not yet loaded and/or missing pieces. Any overflow bits at
    ///     the end are set to zero. When the download was not started yet, this key will not be included in the response.
    /// </summary>
    [JsonProperty("bitfield")]
    public String Bitfield { get; set; } = null!;

    /// <summary>
    ///     Struct which contains information retrieved from the .torrent (file). BitTorrent only. It contains following keys.
    /// </summary>
    [JsonProperty("bittorrent")]
    public DownloadStatusBittorrent? Bittorrent { get; set; }

    /// <summary>
    ///     Completed length of the download in bytes.
    /// </summary>
    [JsonProperty("completedLength")]
    public Int64 CompletedLength { get; set; }

    /// <summary>
    ///     The number of peers/servers aria2 has connected to.
    /// </summary>
    [JsonProperty("connections")]
    public Int64 Connections { get; set; }

    /// <summary>
    ///     Directory to save files.
    /// </summary>
    [JsonProperty("dir")]
    public String Dir { get; set; } = null!;

    /// <summary>
    ///     Download speed of this download measured in bytes/sec.
    /// </summary>
    [JsonProperty("downloadSpeed")]
    public Int64 DownloadSpeed { get; set; }

    /// <summary>
    ///     Returns the list of files. The elements of this list are the same structs used in aria2.getFiles() method.
    /// </summary>
    [JsonProperty("files")]
    public List<DownloadStatusFile> Files { get; set; } = new List<DownloadStatusFile>();

    /// <summary>
    ///     GID of the download.
    /// </summary>
    [JsonProperty("gid")]
    public String Gid { get; set; } = null!;

    /// <summary>
    ///     InfoHash. BitTorrent only.
    /// </summary>
    [JsonProperty("infoHash")]
    public String? InfoHash { get; set; }

    /// <summary>
    ///     The number of pieces.
    /// </summary>
    [JsonProperty("numPieces")]
    public Int64? NumPieces { get; set; }

    /// <summary>
    ///     The number of seeders aria2 has connected to. BitTorrent only.
    /// </summary>
    [JsonProperty("numSeeders")]
    public Int64? NumSeeders { get; set; }

    /// <summary>
    ///     Piece length in bytes.
    /// </summary>
    [JsonProperty("pieceLength")]
    public Int64 PieceLength { get; set; }

    /// <summary>
    ///     true if the local endpoint is a seeder. Otherwise false. BitTorrent only.
    /// </summary>
    [JsonProperty("seeder")]
    public Boolean? Seeder { get; set; }

    /// <summary>
    ///     active for currently downloading/seeding downloads. waiting for downloads in the queue; download is not started.
    ///     paused for paused downloads. error for downloads that were stopped because of error. complete for stopped and
    ///     completed downloads. removed for the downloads removed by user.
    /// </summary>
    [JsonProperty("status")]
    public String Status { get; set; } = null!;

    /// <summary>
    ///     Total length of the download in bytes.
    /// </summary>
    [JsonProperty("totalLength")]
    public Int64 TotalLength { get; set; }

    /// <summary>
    ///     Uploaded length of the download in bytes.
    /// </summary>
    [JsonProperty("uploadLength")]
    public Int64 UploadLength { get; set; }

    /// <summary>
    ///     Upload speed of this download measured in bytes/sec.
    /// </summary>
    [JsonProperty("uploadSpeed")]
    public Int64 UploadSpeed { get; set; }

    /// <summary>
    ///     The code of the last error for this item, if any. The value is a string. The error codes are defined in the EXIT
    ///     STATUS section. This value is only available for stopped/completed downloads.
    /// </summary>
    [JsonProperty("errorCode")]
    public String? ErrorCode { get; set; }

    /// <summary>
    ///     The (hopefully) human readable error message associated to errorCode.
    /// </summary>
    [JsonProperty("errorMessage")]
    public String? ErrorMessage { get; set; }

    /// <summary>
    ///     GID of a parent download. Some downloads are a part of another download. For example, if a file in a Metalink has
    ///     BitTorrent resources, the downloads of ".torrent" files are parts of that parent. If this download has no parent,
    ///     this key will not be included in the response.
    /// </summary>
    [JsonProperty("belongsTo")]
    public String? BelongsTo { get; set; }

    /// <summary>
    ///     List of GIDs which are generated as the result of this download. For example, when aria2 downloads a Metalink file,
    ///     it generates downloads described in the Metalink (see the --follow-metalink option). This value is useful to track
    ///     auto-generated downloads. If there are no such downloads, this key will not be included in the response.
    /// </summary>
    [JsonProperty("followedBy")]
    public List<String>? FollowedBy { get; set; }

    /// <summary>
    ///     The reverse link for followedBy. A download included in followedBy has this object's GID in its following value.
    /// </summary>
    [JsonProperty("following")]
    public String? Following { get; set; }
}

public class DownloadStatusBittorrent
{
    /// <summary>
    ///     List of lists of announce URIs. If the torrent contains announce and no announce-list, announce is converted to the
    ///     announce-list format.
    /// </summary>
    [JsonProperty("announceList")]
    public List<List<String>> AnnounceList { get; set; } = new List<List<String>>();

    /// <summary>
    ///     The comment of the torrent. comment.utf-8 is used if available.
    /// </summary>
    [JsonProperty("comment")]
    public String? Comment { get; set; }

    /// <summary>
    ///     The creation time of the torrent. The value is an integer since the epoch, measured in seconds.
    /// </summary>
    [JsonProperty("creationDate")]
    public Int64 CreationDate { get; set; }

    /// <summary>
    ///     Struct which contains data from Info dictionary. It contains following keys.
    /// </summary>
    [JsonProperty("info")]
    public DownloadStatusBittorrentInfo? Info { get; set; }

    /// <summary>
    ///     File mode of the torrent. The value is either single or multi.
    /// </summary>
    [JsonProperty("mode")]
    public String Mode { get; set; } = null!;

    /// <summary>
    ///     The number of verified number of bytes while the files are being hash checked. This key exists only when this
    ///     download is being hash checked.
    /// </summary>
    [JsonProperty("verifiedLength")]
    public Int64 VerifiedLength { get; set; }

    /// <summary>
    ///     true if this download is waiting for the hash check in a queue. This key exists only when this download is in the
    ///     queue.
    /// </summary>
    [JsonProperty("verifyIntegrityPending")]
    public Boolean VerifyIntegrityPending { get; set; }
}

public class DownloadStatusBittorrentInfo
{
    /// <summary>
    ///     name in info dictionary. name.utf-8 is used if available.
    /// </summary>
    [JsonProperty("name")]
    public String Name { get; set; } = null!;
}

public class DownloadStatusFile
{
    [JsonProperty("completedLength")]
    public Int64 CompletedLength { get; set; }

    [JsonProperty("index")]
    public Int32 Index { get; set; }

    [JsonProperty("length")]
    public Int64 Length { get; set; }

    [JsonProperty("path")]
    public String Path { get; set; } = null!;

    [JsonProperty("selected")]
    public Boolean Selected { get; set; }

    [JsonProperty("uris")]
    public List<DownloadStatusFileUri> Uris { get; set; } = new List<DownloadStatusFileUri>();
}

public class DownloadStatusFileUri
{
    [JsonProperty("status")]
    public String Status { get; set; } = null!;

    [JsonProperty("uri")]
    public String Uri { get; set; } = null!;
}