using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieWatchlist.Services.Movies;
using MovieWatchlist.Middleware;
using MovieWatchlist.DatabaseConnection;
using MovieWatchlist.StartupTasks;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddLogging();
    builder.Services.AddTransient<DatabaseConnectionVerifier>();

    // Add Endpoints API explorer
    builder.Services.AddEndpointsApiExplorer();
    // Add Swagger generator
    builder.Services.AddSwaggerGen();
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
