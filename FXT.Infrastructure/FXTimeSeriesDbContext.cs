using Microsoft.EntityFrameworkCore;
using FXT.Domain.Entities;
using Microsoft.IdentityModel.Protocols;

namespace FXT.Infrastructure.Data
{
    public class FXTimeSeriesDbContext : DbContext
    {
        public FXTimeSeriesDbContext(DbContextOptions<FXTimeSeriesDbContext> options) : base(options)
        {
        }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        private static string _connectionString;



        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=FXTimeSeriesDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CurrencyRate>()
                .ToTable("CurrencyRates")
                .Property(c => c.Rate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Prediction>()
                .ToTable("Predictions")
                .Property(p => p.PredictedRate)
                .HasColumnType("decimal(18,2)");
        }
    }
}
