using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aria2NET;

public class FileResult
{
    /// <summary>
    ///     Completed length of this file in bytes. Please note that it is possible that sum of completedLength is less than
    ///     the completedLength returned by the aria2.tellStatus() method. This is because completedLength in aria2.getFiles()
    ///     only includes completed pieces. On the other hand, completedLength in aria2.tellStatus() also includes partially
    ///     completed pieces.
    /// </summary>
    [JsonProperty("completedLength")]
    public Int64 CompletedLength { get; set; }

    /// <summary>
    ///     Index of the file, starting at 1, in the same order as files appear in the multi-file torrent.
    /// </summary>
    [JsonProperty("index")]
    public Int32 Index { get; set; }

    /// <summary>
    ///     File size in bytes.
    /// </summary>
    [JsonProperty("length")]
    public Int64 Length { get; set; }

    /// <summary>
    ///     File path.
    /// </summary>
    [JsonProperty("path")]
    public String Path { get; set; }

    /// <summary>
    ///     true if this file is selected by --select-file option. If --select-file is not specified or this is single-file
    ///     torrent or not a torrent download at all, this value is always true. Otherwise false.
    /// </summary>
    [JsonProperty("selected")]
    public Boolean Selected { get; set; }

    /// <summary>
    ///     Returns a list of URIs for this file. The element type is the same struct used in the aria2.getUris() method.
    /// </summary>
    [JsonProperty("uris")]
    public List<UriResult> Uris { get; set; }
}