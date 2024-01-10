using MovieWatchlist.RequestCounter;
using Microsoft.EntityFrameworkCore;
using Repositories.MovieWatchlist;
using Services.MovieWatchlist;
using DatabaseConnection;
using Repositories.User;
using Services.User;
using Cryptography;
using Middlewares;
using AppStartup;

var builder = WebApplication.CreateBuilder(args);

{
    // Database Configuration
    builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
    builder.Services.AddScoped<UserManager>();
    builder.Services.AddScoped<MovieManager>();

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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

{
    // Verify database connection
    StartupTasks.VerifyDatabaseConnection(app);

    // Rquest Timing Middleware
    app.UseTiming();

    // Exception Handler Middleware
    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

    app.UseHttpsRedirection();
    app.UseRouting();

    // Auth Middlewares
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
}
