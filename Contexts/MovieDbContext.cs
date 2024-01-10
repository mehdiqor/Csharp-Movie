using Microsoft.EntityFrameworkCore;
using UserAuthentication.Models;
using MovieWatchlist.Models;

namespace DatabaseConnection;

public class MovieDbContext : DbContext
{
  public MovieDbContext(DbContextOptions<MovieDbContext> options)
    : base(options)
  {
  }

  public DbSet<Movie>? Movies { get; set; }
  public DbSet<UserAuth>? Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Movie>()
        .HasKey(m => m.Id);

    modelBuilder.Entity<UserAuth>()
        .HasKey(u => u.Id);

    base.OnModelCreating(modelBuilder);
  }
}
