using Microsoft.EntityFrameworkCore;

namespace NaLibApi.Data
{
    public class NaLibDbContext : DbContext
    {
        public NaLibDbContext(DbContextOptions<NaLibDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}