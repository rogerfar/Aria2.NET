# Aria2.NET

Aria2c .NET wrapper library written in C#

Supports all methods for the HTTP RPC Aria2 client.

## Usage

Setup Aria2c with RPC access enabled:
```
enable-rpc=true
rpc-allow-origin-all=true
rpc-listen-all=true
rpc-listen-port=6801
rpc-secret=mysecret123
```

Create an instance of `Aria2NetClient` for each Aria2c instance you want to connect to.

```csharp
var client = new Aria2NetClient("http://127.0.0.1:6801/jsonrpc", "mysecret123");
```

The Client follows the official API naming, for example:
```csharp
var client = new Aria2NetClient("http://127.0.0.1:6801/jsonrpc", "mysecret123");

// https://aria2.github.io/manual/en/html/aria2c.html#aria2.addUri
client.AddUriAsync(new List<String>
{
    "https://speed.hetzner.de/1GB.bin"
},
new Dictionary<String, Object>
{
    { "dir", "C:/Temp"}
}, 0);
```

In the first example the first parameter is the URL, the 2nd parameter is a list of options you can pass to Aria2c in dictionary form.

## Unit tests

The unit tests are not designed to be ran all at once, they are used to act as a test client.

Change the values in `Setup.cs`.