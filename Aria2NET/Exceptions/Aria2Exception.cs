using System;

namespace Aria2NET.Exceptions;

public class Aria2Exception : Exception
{
    public Aria2Exception(Int64 resultCode, String resultMessage) : base($"Error {resultCode}: {resultMessage}")
    {
        ResultCode = resultCode;
        ResultMessage = resultMessage;
    }

    public String ResultMessage { get; }

    public Int64 ResultCode { get; }
}