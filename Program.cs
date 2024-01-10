using MovieWatchlist.DatabaseConnection;
using UserAuthentication.Services.Users;
using MovieWatchlist.Services.Movies;
using MovieWatchlist.RequestCounter;
using Microsoft.EntityFrameworkCore;
using MovieWatchlist.StartupTasks;
using Microsoft.OpenApi.Models;
using Cryptography;
using Middlewares;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<CryptographyService>();
    builder.Services.AddLogging();
    builder.Services.AddTransient<DatabaseConnectionVerifier>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSingleton<IRequestCounter, RequestCounter>();
    builder.Services.AddSingleton<IJwtValidator, JwtValidator>();

    // Database Configuration
    builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Swagger Configuration
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });
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

    app.UseExceptionHandler("/error");
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
