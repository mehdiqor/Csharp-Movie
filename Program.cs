using Microsoft.EntityFrameworkCore;
using MovieWatchlist.Repositories;
using MovieWatchlist.Middlewares;
using MovieWatchlist.Contexts;
using MovieWatchlist.Managers;
using MovieWatchlist.Services;
using MovieWatchlist.Helpers;
using MovieWatchlist;

var builder = WebApplication.CreateBuilder(args);

{
    // Database Configuration
    builder.Services.AddDbContext<MovieDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddTransient<DatabaseConnectionVerifier>();

    // Global Configurations
    builder.Services.AddSingleton<IRequestCounter, RequestCounter>();
    builder.Services.AddSingleton<IJwtValidator, JwtValidator>();
    builder.Services.AddScoped<CryptographyService>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddLogging();

    // Controllers
    builder.Services.AddControllers();

    // Managers
    builder.Services.AddScoped<IUserManager, UserManager>();
    builder.Services.AddScoped<IMovieManager, MovieManager>();

    // Services
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddScoped<IUserService, UserService>();

    // Repositories
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IMovieRepository, MovieRepository>();

    // Swagger Configuration
    SwaggerConfig.ConfigureSwagger(builder.Services);
}

// Build application
var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Watchlist"); });
}

{
    // Verify database connection
    StartupTasks.VerifyDatabaseConnection(app);

    // Request Timing Middleware
    app.UseTiming();

    // Exception Handler Middleware
    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.UseHttpsRedirection();
    app.UseRouting();

    // Auth Middlewares
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.Run();
}