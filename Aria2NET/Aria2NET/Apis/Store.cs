using System;

namespace Aria2NET.Apis
{
    internal class Store
    {
        public String Aria2Url { get; set; }
        public String Secret { get; set; }
        public Int32 RetryCount { get; set; }
    }
}
