using Microsoft.EntityFrameworkCore;
using ResultsApi.Models;

namespace ResultsApi.Data
{
    public class ResultsContext : DbContext, IResultsContext
    {

        public ResultsContext (DbContextOptions<ResultsContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Log> Logs { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(e => e.Id);
                x.Property(e => e.Password).IsRequired();
                x.HasIndex(e => e.Username).IsUnique();
                x.Property(e => e.Salt).IsRequired();
            });

            modelBuilder.Entity<Result>(x =>
            {
                x.HasKey(e => e.Id);
                x.Property(e => e.Student).IsRequired();
                x.Property(e => e.Subject).IsRequired();
                x.Property(e => e.Score).IsRequired();
                x.Property(e => e.Grade).IsRequired();
            });

            modelBuilder.Entity<Log>(x =>
            {
                x.HasKey(e => e.Id);
                x.Property(e => e.Instance).IsRequired();
                x.Property(e => e.Message).IsRequired();
                x.Property(e => e.StackTrace).IsRequired();
                x.Property(e => e.AddDate).IsRequired();
            });
        }
    }
}
