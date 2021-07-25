using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aria2NET.Apis;
using Aria2NET.Models;

namespace Aria2NET
{
    /// <summary>
    ///     Documentation about the API can be found here:
    ///     https://aria2.github.io/manual/en/html/aria2c.html#json-rpc-using-http-get
    /// </summary>
    public class Aria2NetClient
    {
        private readonly Requests _requests;

        /// <summary>
        ///     Initialize the Aria2NetClient API.
        /// </summary>
        /// <param name="aria2Url">
        ///     The URL to your aria2 instance. Must end in /jsonrpc, for example: http://127.0.0.1:6801/jsonrpc.
        ///     To use SSL, use https.
        /// </param>
        /// <param name="secret">
        ///     Optional secret to your RPC instance.
        /// </param>
        /// <param name="httpClient">
        ///     Optional HttpClient if you want to use your own HttpClient.
        /// </param>
        public Aria2NetClient(String aria2Url, String secret = null, HttpClient httpClient = null)
        {
            if (!aria2Url.EndsWith("/jsonrpc"))
            {
                throw new Exception($"The URL must end with /jsonrpc");
            }

            var store = new Store
            {
                Aria2Url = aria2Url,
                Secret = secret
            };

            var client = httpClient ?? new HttpClient();

            _requests = new Requests(client, store);
        }

        /// <summary>
        ///     This method adds a new download.
        /// </summary>
        /// <param name="uriList">
        ///     UriList is a list of HTTP/FTP/SFTP/BitTorrent URIs (strings) pointing to the same resource. If you mix URIs
        ///     pointing to different resources, then the download may fail or be corrupted without aria2 complaining. When adding
        ///     BitTorrent Magnet URIs, uris must have only one element and it should be BitTorrent Magnet URI.
        /// </param>
        /// <param name="options">
        ///     For all available options see: https://aria2.github.io/manual/en/html/aria2c.html#id2.
        /// </param>
        /// <param name="position">
        ///     If position is given, it must be an integer starting from 0. The new download will be inserted at position in the
        ///     waiting queue. If position is omitted or position is larger than the current size of the queue, the new download is
        ///     appended to the end of the queue.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of the newly registered download</returns>
        public async Task<String> AddUri(IList<String> uriList, IDictionary<String, Object> options = null, Int32? position = null, CancellationToken cancellationToken = default)
        {
            if (uriList == null || uriList.Count == 0)
            {
                throw new ArgumentException("UriList cannot be null or empty");
            }

            options ??= new Dictionary<String, Object>();

            return await _requests.GetRequestAsync<String>("aria2.addUri", cancellationToken, uriList, options, position);
        }

        /// <summary>
        ///     This method adds a new BitTorrent download.
        /// </summary>
        /// <param name="torrent">
        ///     Contents of the .torrent file.
        /// </param>
        /// <param name="uriList">
        ///     Uris is used for Web-seeding. For single file torrents, the URI can be a complete URI pointing to the resource; if
        ///     URI ends with /, name in torrent file is added. For multi-file torrents, name and path in torrent are added to form
        ///     a URI for each file.
        /// </param>
        /// <param name="options">
        ///     For all available options see: https://aria2.github.io/manual/en/html/aria2c.html#id2.
        /// </param>
        /// <param name="position">
        ///     If position is given, it must be an integer starting from 0. The new download will be inserted at position in the
        ///     waiting queue. If position is omitted or position is larger than the current size of the queue, the new download is
        ///     appended to the end of the queue.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of the newly registered download.</returns>
        public async Task<String> AddTorrent(Byte[] torrent,
                                             IList<String> uriList = null,
                                             IDictionary<String, Object> options = null,
                                             Int32? position = null,
                                             CancellationToken cancellationToken = default)
        {
            var torrentFile = Convert.ToBase64String(torrent);

            uriList ??= new List<String>();
            options ??= new Dictionary<String, Object>();

            return await _requests.GetRequestAsync<String>("aria2.addTorrent", cancellationToken, torrentFile, uriList, options, position);
        }

        /// <summary>
        ///     This method returns the version of aria2 and the list of enabled features.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The version and enabled features.</returns>
        public async Task<VersionResult> GetVersion(CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<VersionResult>("aria2.getVersion", cancellationToken);
        }

        /// <summary>
        ///     This method adds a Metalink download.
        /// </summary>
        /// <param name="torrent">
        ///     Contents of the .metalink file.
        /// </param>
        /// <param name="options">
        ///     For all available options see: https://aria2.github.io/manual/en/html/aria2c.html#id2.
        /// </param>
        /// <param name="position">
        ///     If position is given, it must be an integer starting from 0. The new download will be inserted at position in the
        ///     waiting queue. If position is omitted or position is larger than the current size of the queue, the new download is
        ///     appended to the end of the queue.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of GIDs of newly registered downloads.</returns>
        public async Task<List<String>> AddMetalink(Byte[] torrent,
                                                    IDictionary<String, Object> options = null,
                                                    Int32? position = null,
                                                    CancellationToken cancellationToken = default)
        {
            var torrentFile = Convert.ToBase64String(torrent);

            options ??= new Dictionary<String, Object>();

            return await _requests.GetRequestAsync<List<String>>("aria2.addMetalink", cancellationToken, torrentFile, options, position);
        }

        /// <summary>
        ///     This method removes the download denoted by gid. If the specified download is in progress, it is first
        ///     stopped. The status of the removed download becomes removed.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of removed download.</returns>
        public async Task<String> Remove(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<String>("aria2.remove", cancellationToken, gid);
        }

        /// <summary>
        ///     This method removes the download denoted by gid. This method behaves just like aria2.remove() except that this
        ///     method removes the download without performing any actions which take time, such as contacting BitTorrent trackers
        ///     to unregister the download first.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of removed download.</returns>
        public async Task<String> ForceRemove(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<String>("aria2.forceRemove", cancellationToken, gid);
        }

        /// <summary>
        ///     This method pauses the download denoted by gid (string). The status of paused download becomes paused. If the
        ///     download was active, the download is placed in the front of waiting queue. While the status is paused, the download
        ///     is not started. To change status to waiting, use the aria2.unpause() method.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of paused download.</returns>
        public async Task<String> Pause(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<String>("aria2.pause", cancellationToken, gid);
        }

        /// <summary>
        ///     This method is equal to calling Pause() for every active/waiting download.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>True if successful.</returns>
        public async Task<Boolean> PauseAll(CancellationToken cancellationToken = default)
        {
            var result = await _requests.GetRequestAsync<String>("aria2.pauseAll", cancellationToken);

            return result == "OK";
        }

        /// <summary>
        ///     This method pauses the download denoted by gid. This method behaves just like aria2.pause() except that this method
        ///     pauses downloads without performing any actions which take time, such as contacting BitTorrent trackers to
        ///     unregister the download first.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of paused download.</returns>
        public async Task<String> ForcePause(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<String>("aria2.forcePause", cancellationToken, gid);
        }

        /// <summary>
        ///     This method is equal to calling ForcePause() for every active/waiting download.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>True if successful.</returns>
        public async Task<Boolean> ForcePauseAll(CancellationToken cancellationToken = default)
        {
            var result = await _requests.GetRequestAsync<String>("aria2.forcePauseAll", cancellationToken);

            return result == "OK";
        }

        /// <summary>
        ///     This method changes the status of the download denoted by gid (string) from paused to waiting, making the download
        ///     eligible to be restarted.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The GID of unpaused download.</returns>
        public async Task<String> Unpause(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<String>("aria2.unpause", cancellationToken, gid);
        }

        /// <summary>
        ///     This method is equal to calling ForcePause() for every active/waiting download.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>True if successful.</returns>
        public async Task<Boolean> UnpauseAll(CancellationToken cancellationToken = default)
        {
            var result = await _requests.GetRequestAsync<String>("aria2.unpauseAll", cancellationToken);

            return result == "OK";
        }

        /// <summary>
        ///     This method returns the progress of the download denoted by gid (string). keys is an array of strings.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Status of the download.</returns>
        public async Task<DownloadStatusResult> TellStatus(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<DownloadStatusResult>("aria2.tellStatus", cancellationToken, gid);
        }

        /// <summary>
        ///     This method returns the URIs used in the download denoted by gid (string).
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of urls.</returns>
        public async Task<IList<UriResult>> GetUris(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<List<UriResult>>("aria2.getUris", cancellationToken, gid);
        }

        /// <summary>
        ///     This method returns the file list of the download denoted by gid (string).
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of files.</returns>
        public async Task<IList<FileResult>> GetFiles(String gid, CancellationToken cancellationToken = default)
        {
            return await _requests.GetRequestAsync<List<FileResult>>("aria2.getFiles", cancellationToken, gid);
        }
    }
}
