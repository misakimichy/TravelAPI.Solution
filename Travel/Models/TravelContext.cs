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
        // public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Country>()
            .HasData(
                new Country { CountryId = 1, Name = "Japan"},
                new Country { CountryId = 2, Name = "England"},
                new Country { CountryId = 3, Name = "Japan"},
                new Country { CountryId = 4, Name = "Taiwan"},
                new Country { CountryId = 5, Name = "Brazil"}
            );
        }
    }
}