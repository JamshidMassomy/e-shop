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
        }
    }
}
