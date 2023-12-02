namespace ResultsApi.Models;

public sealed class Result {
    public int Id { get; set; }
    public string Student { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public int Score { get; set; }
    public string Grade { get; set; } = string.Empty;

}

