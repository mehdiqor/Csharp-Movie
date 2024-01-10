namespace Middlewares;

public interface IJwtValidator
{
    bool ValidateToken(string token);
}
