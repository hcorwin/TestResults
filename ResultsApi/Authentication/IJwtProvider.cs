namespace ResultsApi.Authentication;

public interface IJwtProvider
{
    string GenerateToken(string username);
}