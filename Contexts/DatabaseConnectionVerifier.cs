using Microsoft.Data.SqlClient;

namespace MovieWatchlist.Contexts;

public class DatabaseConnectionVerifier
{
    private readonly ILogger<DatabaseConnectionVerifier> _logger;

    public DatabaseConnectionVerifier(ILogger<DatabaseConnectionVerifier> logger)
    {
        _logger = logger;
    }

    public bool IsServerConnected(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);
        try
        {
            _logger.LogInformation("Attempting to open connection to SqlServer");

            connection.Open();

            _logger.LogInformation("Successfully opened connection to SqlServer");

            return true;
        }
        catch (SqlException ex)
        {
            _logger.LogError("Failed to open connection, reason: {ex}", ex.Message);

            return false;
        }
    }
}