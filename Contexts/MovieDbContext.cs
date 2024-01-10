using Microsoft.EntityFrameworkCore;
using MovieWatchlist.Models;

namespace MovieWatchlist.DatabaseConnection;

public class MovieDbContext : DbContext
{
  public MovieDbContext(DbContextOptions<MovieDbContext> options)
    : base(options)
  {
  }

  public DbSet<Movie>? Movies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Movie>()
        .HasKey(m => m.Id);

    base.OnModelCreating(modelBuilder);
  }
}
