using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultsApi.Authentication;
using ResultsApi.Data;
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
        private readonly IResultsContext _dbContext;
        private readonly IJwtProvider _tokenService;

        public UsersController(
            IPasswordEncryptionService encryptionService,
            ILogWriter logger,
            IResultsContext dbContext,
            IJwtProvider tokenService)
        {
            _encryptionService = encryptionService;
            _logger = logger;
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Username.Equals(username));

            if (user is not null) return BadRequest("User already exists");

            var salt = _encryptionService.GenerateSalt();

            var newUser = new User
            {
                Username = username,
                Password = _encryptionService.HashPassword(password, salt),
                Salt = Convert.ToBase64String(salt)
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("login")]
        public async Task<ActionResult> Login(string username, string password)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Username.Equals(username));

            if (existingUser is null) return BadRequest("User not found");

            var token = _tokenService.GenerateToken(username);

            return _encryptionService.IsPasswordEqual(password, existingUser.Password,
                Convert.FromBase64String(existingUser.Salt))
                ? Ok(token)
                : BadRequest("Login failed");
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult AuthTest()
        {
            return Ok();
        }
    }
}
