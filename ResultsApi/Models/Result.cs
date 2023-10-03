namespace ResultsApi.Models;

public sealed class Result {
    public int Id { get; set; }
    public string Student { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
    public string Grade { get; set; }

}

