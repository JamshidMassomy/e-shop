using Shop.Domain.Entities.Common;

namespace Shop.Application.Features.Item
{
    public record ItemResponse
    {
        public ItemId Id { get; init; } 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
