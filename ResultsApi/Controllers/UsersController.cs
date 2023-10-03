using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultsApi.Logging;
using ResultsApi.Models;
using ResultsApi.Services;

namespace ResultsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPasswordEncryptionService _encryptionService;
        private readonly ILogWriter _logger;

        public UsersController(
            IPasswordEncryptionService encryptionService,
            ILogWriter logger)
        {
            _encryptionService = encryptionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Register(string username, string password)
        {
            await _logger.LogMessage(new Log
            {
                Instance = "UsersController",
                StackTrace = "no stack",
                Message = "testing message",
                AddDate = DateTime.Now
            });
            return Ok();
        }
    }
}
