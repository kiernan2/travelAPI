using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
  public class TravelApiContext : DbContext
  {
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Location> Locations { get; set; }

    public TravelApiContext(DbContextOptions<TravelApiContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Review>()
        .HasData(
          new Review { ReviewId = 1, Author = "Arthur", Rating = 4, ReviewText = "Space for rent", LocationId = 1},
          new Review { ReviewId = 2, Author = "Catherine", Rating = 2, ReviewText = "By reading this you've given access to the malware I put in this program", LocationId = 2}
        );
    }
  }
}