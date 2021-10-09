using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Aria2NET.Test
{
    public class ApiTest
    {
        [Fact]
        public async Task GetVersion()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetVersion();

            Assert.Equal("1.35.0", result.Version);
        }

        [Fact]
        public async Task AddUri()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.AddUri(new List<String>
                                {
                                    "https://speed.hetzner.de/1GB.bin"
                                },
                                new Dictionary<String, Object>
                                {
                                    { "dir", "C:/Temp"}
                                }, 0);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddTorrentFile()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            const String filePath = @"big-buck-bunny.torrent";

            var file = await File.ReadAllBytesAsync(filePath);

            var result = await client.AddTorrent(file, 
                                    null,
                                    new Dictionary<String, Object>
                                    {
                                        { "dir", "C:/Temp"}
                                    }, 0);

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task AddMetalink()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            const String filePath = @"metalink4.xml";

            var file = await File.ReadAllBytesAsync(filePath);

            var result = await client.AddMetalink(file, 
                                                  new Dictionary<String, Object>
                                                  {
                                                      { "dir", "C:/Temp"}
                                                  }, 0);

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task Remove()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.Remove("fe63a1c15db1a244");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task ForceRemove()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.ForceRemove("fe63a1c15db1a244");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TellStatus()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.TellStatus("a7ac79f1717e70c4");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetUris()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetUris("8513206cea07bd3c");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetFiles()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetFiles("8513206cea07bd3c");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetPeers()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetPeers("d13f0b120af20416");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetServers()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetServers("a6e32d335684191a");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetGlobalOption()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetGlobalOption();

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task ChangeGlobalOption()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            await client.ChangeGlobalOption(new Dictionary<String, String>
            {
                {"bt-max-peers", "60"}
            });
        }
        
        [Fact]
        public async Task GetSessionInfo()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var sessionId = await client.GetSessionInfo();

            Assert.NotNull(sessionId);
        }

        [Fact]
        public async Task GetGlobalStat()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var globalStats = await client.GetGlobalStat();

            Assert.NotNull(globalStats);
        }
    }
}
