using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aria2NET
{
    public class Request
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("jsonrpc")]
        public String Jsonrpc { get; set; }

        [JsonProperty("method")]
        public String Method { get; set; }

        [JsonProperty("params")]
        public IList<Object> Parameters { get; set; }
    }

    public class MulticallRequest
    {
        [JsonProperty("methodName")]
        public String MethodName { get; set; }

        [JsonProperty("params")]
        public IList<Object> Parameters { get; set; }
    }
}
