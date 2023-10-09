using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(e => new { e.CartId, e.Id });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellLog> SellLogs { get; set; }
    }
}
