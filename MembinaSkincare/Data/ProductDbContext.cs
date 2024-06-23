using Microsoft.EntityFrameworkCore;
using MembinaSkincare.Models.Domain;

namespace MembinaSkincare.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the relationship between Product and Currency
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Currency)
                .WithMany(c => c.Products) // This line is optional and is for navigation from Currency to Products
                .HasForeignKey(p => p.CurrencyId);
        }
    }
}
