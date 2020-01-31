using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Models
{
    public class TravelAPIContext : DbContext
    {
        public TravelAPIContext(DbContextOptions<TravelAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Place> Places{ get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Place>()
                .HasData(
                    new Place { PlaceId = 1, City = "Tokyo", Country = "Japan", Rating = 3},
                    new Place { PlaceId = 2, City = "Seattle", Country = "US", Rating = 4},
                    new Place { PlaceId = 3, City = "London", Country = "England", Rating = 3.5},
                    new Place { PlaceId = 4, City = "Taipei", Country = "Taiwan", Rating = 5},
                    new Place { PlaceId = 5, City = "Rio", Country = "Brazil", Rating = 0}
                );
            
            builder.Entity<Review>()
                .HasData(
                    new Review { ReviewId = 1, ReviewText = "Great!", PlaceId = 1, Rating = 2, UserName = "user1"},
                    new Review { ReviewId = 2, ReviewText = "I hated this place!", PlaceId = 2, Rating = 1, UserName = "user2"},
                    new Review { ReviewId = 3, ReviewText = "Highly recommend!!", PlaceId = 3,  Rating = 4.5, UserName = "user1"},
                    new Review { ReviewId = 4, ReviewText = "I loved this place. I will come back!", PlaceId = 4, Rating = 5, UserName = "user2"},
                    new Review { ReviewId = 5, ReviewText = "It was ok.", PlaceId = 5, Rating = 3.5, UserName = "user2"}
                );
        }
    }
}