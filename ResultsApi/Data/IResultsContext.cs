using Microsoft.EntityFrameworkCore;
using ResultsApi.Models;

namespace ResultsApi.Data;

public interface IResultsContext
{
    DbSet<User> Users { get; set; }
    DbSet<Result> Results { get; set; }
    DbSet<Log> Logs { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}