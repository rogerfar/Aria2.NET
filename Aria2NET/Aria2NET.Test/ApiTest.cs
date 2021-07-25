using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Aria2NET.Test
{
    public class ApiTest
    {
        [Fact]
        public async Task AddUri()
        {
            var client = new Aria2NetClient(Setup.URL);

            await client.AddUri(new List<String>
                                {
                                    "https://download.nullsoft.com/winamp/client/winamp58_3660_beta_full_en-us.exe"
                                },
                                new Dictionary<String, Object>
                                {
                                    { "dir", "C:/Temp"}
                                }, 0);
        }
    }
}
