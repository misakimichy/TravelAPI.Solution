using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>()
                .HasData(
                    new Country { CountryId = 1, Name = "Japan", Rating = 5},
                    new Country { CountryId = 2, Name = "England", Rating = 5},
                    new Country { CountryId = 3, Name = "Japan", Rating = 1},
                    new Country { CountryId = 4, Name = "Taiwan", Rating = 5},
                    new Country { CountryId = 5, Name = "Brazil", Rating = 5}
                );
            
            builder.Entity<City>()
                .HasData(
                    new City { CityId = 1, Name = "Tokyo", Rating = 5},
                    new City { CityId = 2, Name = "London", Rating = 3},
                    new City { CityId = 3, Name = "Kyoto", Rating = 1},
                    new City { CityId = 4, Name = "Taipei", Rating = 5},
                    new City { CityId = 5, Name = "Rio", Rating = 3}
                );
        }
    }
}