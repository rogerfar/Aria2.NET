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
            var client = new Aria2NetClient(Setup.URL, Setup.Secret, null, 5);

            var result = await client.GetVersionAsync();

            Assert.Equal("1.36.0", result.Version);
        }

        [Fact]
        public async Task AddUri()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.AddUriAsync(new List<String>
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

            var result = await client.AddTorrentAsync(file, 
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

            var result = await client.AddMetalinkAsync(file, 
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

            var result = await client.RemoveAsync("fe63a1c15db1a244");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task ForceRemove()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.ForceRemoveAsync("fe63a1c15db1a244");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TellStatus()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret, null, 1);

            var result = await client.TellStatusAsync("a7ac79f1717e70c4");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TellActive()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.TellActiveAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TellStopped()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.TellStoppedAsync(0, 1000);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TellWaiting()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.TellWaitingAsync(0, 1000);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TellAll()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.TellAllAsync();

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetUris()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetUrisAsync("8513206cea07bd3c");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetFiles()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetFilesAsync("8513206cea07bd3c");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetPeers()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetPeersAsync("d13f0b120af20416");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetServers()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetServersAsync("a6e32d335684191a");

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetGlobalOption()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            var result = await client.GetGlobalOptionAsync();

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task ChangeGlobalOption()
        {
            var client = new Aria2NetClient(Setup.URL, Setup.Secret);

            await client.ChangeGlobalOptionAsync(new Dictionary<String, String>
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

            var globalStats = await client.GetGlobalStatAsync();

            Assert.NotNull(globalStats);
        }
    }
}
