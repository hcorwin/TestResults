using ResultsApi.Models;

namespace ResultsApi.Logging;

public interface ILogWriter
{
    ValueTask LogMessage(Log log);
}