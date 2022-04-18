using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aria2NET;

public class VersionResult
{
    /// <summary>
    /// List of enabled features. Each feature is given as a string.
    /// </summary>
    [JsonProperty("enabledFeatures")]
    public List<String> EnabledFeatures { get; set; }

    /// <summary>
    /// Version number of aria2 as a string.
    /// </summary>
    [JsonProperty("version")]
    public String Version { get; set; }
}