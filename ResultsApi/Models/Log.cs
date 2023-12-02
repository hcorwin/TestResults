namespace ResultsApi.Models
{
    public sealed class Log{
        public int Id { get; set; }
        public string Instance { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public DateTime AddDate { get; set; }

    }
}