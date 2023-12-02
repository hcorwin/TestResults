using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultsApi.Data;

namespace ResultsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ResultsController : ControllerBase
    {
        private readonly IResultsContext _dbContext;

        public ResultsController(
            IResultsContext context)
        {
            _dbContext = context;
        }

        [Authorize]
        [HttpGet("results")]
        public async Task<ActionResult> GetResults()
        {
            var results = await _dbContext.Results.ToListAsync();
            return Ok(results);
        }
    }
}
