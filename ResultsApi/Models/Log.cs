namespace ResultsApi.Models
{
    public sealed class Log{
        public int Id { get; set; }
        public string Instance { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime AddDate { get; set; }

    }
}