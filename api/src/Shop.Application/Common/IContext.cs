using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Item;

namespace Shop.Application.Common
{
    public interface IContext : IAsyncDisposable, IDisposable
    {
        public DatabaseFacade Database { get; }

        public DbSet<Item> Items { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
