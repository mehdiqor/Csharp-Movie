using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MovieWatchlist.DatabaseConnection;
using System;

namespace MovieWatchlist.StartupTasks;

public static class StartupTasks
{
    public static void VerifyDatabaseConnection(WebApplication app)
    {
        var serviceProvider = app.Services;
        var dbVerifier = serviceProvider.GetRequiredService<DatabaseConnectionVerifier>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var isServerConnected = dbVerifier.IsServerConnected(configuration.GetConnectionString("DefaultConnection"));

        if (!isServerConnected)
        {
            throw new InvalidOperationException("Unable to connect to the database");
        }
    }
}

