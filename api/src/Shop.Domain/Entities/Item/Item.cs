using MassTransit;
using Shop.Domain.Entities.Common;

namespace Shop.Domain.Entities.Item
{
    public class Item: Entity<ItemId>
    {
        public override ItemId Id { get; set; } = NewId.NextGuid();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
