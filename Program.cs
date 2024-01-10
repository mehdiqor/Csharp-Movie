using MovieWatchlist.DatabaseConnection;
using MovieWatchlist.Services.Movies;
using MovieWatchlist.StartupTasks;
using MovieWatchlist.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddLogging();
    builder.Services.AddTransient<DatabaseConnectionVerifier>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable middleware for serving the generated JSON document and the Swagger UI
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

    // app.Use(async (ctx, next) =>
    // {
    //     app.Logger.LogWarning("in middleware");

    //     await next.Invoke(ctx);
    // });

    app.UseTiming();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    // app.UseAuthorization();
    app.Run();
}
