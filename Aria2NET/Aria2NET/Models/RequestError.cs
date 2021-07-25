using System;
using Newtonsoft.Json;

namespace Aria2NET.Models
{
    public class RequestError
    {
        [JsonProperty("code")]
        public Int64 Code { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }
    }
}
