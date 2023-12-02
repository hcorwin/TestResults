using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResultsApi.Logging;
using ResultsApi.Models;

namespace ResultsApi.ErrorHandling
{
    public sealed class ApiExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogWriter _logger;

        public ApiExceptionFilter(ILogWriter logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var log = new Log
            {
                Instance = context.Exception.Source ?? "unknown",
                AddDate = DateTime.Now,
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace ?? "unknown"
            };

            context.Result = new StatusCodeResult(500);

            await _logger.LogMessage(log);
        }
    }
}
