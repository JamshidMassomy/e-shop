using MediatR;
using Shop.Application.Common.Request;
using Shop.Application.Response;

namespace Shop.Application.Features.Item.GetAllItem
{
    public record GetAllItemRequest: PaginatedRequest, IRequest<PaginatedList<ItemResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
