using ResultsApi.Models;

namespace ResultsApi.Data
{
    public static class SeedData
    {
        public static async Task Seed(this ResultsContext context)
        {
            if (!context.Results.Any())
            {
                var results = new List<Result>
                {
                    new Result
                    {
                        Student = "Holden",
                        Subject = "Math",
                        Grade = "A",
                        Score = 96
                    },
                    new Result
                    {
                        Student = "Nick",
                        Subject = "English",
                        Grade = "A",
                        Score = 92
                    },
                    new Result
                    {
                        Student = "Ryan",
                        Subject = "Science",
                        Grade = "C",
                        Score = 74
                    },
                    new Result
                    {
                        Student = "Kyle",
                        Subject = "History",
                        Grade = "B",
                        Score = 87
                    }
                };

                context.Results.AddRange(results);
                await context.SaveChangesAsync();
            }
        }
    }
}
