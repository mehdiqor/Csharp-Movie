using MovieWatchlist.Contexts;

namespace MovieWatchlist;

public static class StartupTasks
{
    private static ILogger? _logger;

    public static void Initialize(ILogger logger)
    {
        _logger = logger;
    }

    public static void VerifyDatabaseConnection(WebApplication app)
    {
        var serviceProvider = app.Services;
        var dbVerifier = serviceProvider.GetRequiredService<DatabaseConnectionVerifier>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var isServerConnected = dbVerifier.IsServerConnected(configuration.GetConnectionString("DefaultConnection"));

        if (!isServerConnected)
        {
            _logger?.LogError("Unable to connect to the database");
        }
    }
}