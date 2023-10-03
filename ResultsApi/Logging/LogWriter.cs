using System.Threading.Channels;
using ResultsApi.Models;

namespace ResultsApi.Logging;

public sealed class LogWriter : ILogWriter
{
    private readonly ChannelWriter<Log> _channel;

    public LogWriter(ChannelWriter<Log> channel)
    {
        _channel = channel;
    }

    public ValueTask LogMessage(Log log) =>
        _channel.WriteAsync(log);

}

