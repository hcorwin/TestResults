using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using ResultsApi.Data;
using ResultsApi.Models;

namespace ResultsApi.Logging
{
    public class LoggingService : BackgroundService
    {
        private readonly ChannelReader<Log> _channel;
        private readonly IDbContextFactory<ResultsContext> _dbContextFactory;

        public LoggingService(
            ChannelReader<Log> channel,
            IDbContextFactory<ResultsContext> resultsContextFactory)
        {
            _channel = channel;
            _dbContextFactory = resultsContextFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var item in _channel.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await using var dbContext = await _dbContextFactory.CreateDbContextAsync(stoppingToken);
                    dbContext.Logs.Add(item);
                    await dbContext.SaveChangesAsync(stoppingToken);
                }
                catch (Exception e)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        EventLog.WriteEntry("LoggingService", e.Message);
                }
            }
        }
    }
}
