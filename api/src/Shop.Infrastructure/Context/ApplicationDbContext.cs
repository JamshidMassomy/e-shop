using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Domain.Entities.Item;
using Shop.Infrastructure.Configuration;

namespace Shop.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemConfiguration).Assembly);
           modelBuilder.Entity<Item>().HasData(
            new Item { Name = "Iphone14", Price = 900, Quantity = 2, Description = "Apple Iphone newest product", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Item { Name = "Andriod", Price = 800,  Quantity = 5, Description = "Andriod Mobile phone", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Item { Name = "Laptop", Price = 700, Quantity = 6, Description = "Dell Laptop", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
   );
        }
    }
}
