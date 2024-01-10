using MovieWatchlist.Services.Movies;
using MovieWatchlist.RequestCounter;
using Microsoft.EntityFrameworkCore;
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

    builder.Services.AddControllers();
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<CryptographyService>();
    builder.Services.AddLogging();
    builder.Services.AddTransient<DatabaseConnectionVerifier>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSingleton<IRequestCounter, RequestCounter>();
    builder.Services.AddSingleton<IJwtValidator, JwtValidator>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<UserManager>();


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

    // Middlewares
    app.UseTiming();

    // app.UseExceptionHandler("/error");
    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
}
