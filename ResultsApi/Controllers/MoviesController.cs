using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultsApi.Data;

namespace ResultsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class MoviesController : ControllerBase
    {
        private readonly IResultsContext _dbContext;

        public MoviesController(
            IResultsContext context)
        {
            _dbContext = context;
        }

        [Authorize]
        [HttpGet("movies")]
        public async Task<ActionResult> GetMovies()
        {
            var movies = await _dbContext.Movies.ToListAsync();

            var moviesWithBase64Image = movies.Select(x => new
            {
                x.Id,
                x.Title,
                x.Description,
                Image = Convert.ToBase64String(x.Image),
                x.VideoId,
                x.Price,
            }).ToList();

            return Ok(moviesWithBase64Image);
        }
    }
}
