using Ardalis.Result;
using MediatR;

namespace Shop.Application.Features.Item.CreateItem
{
    public record CreateItemRequest: IRequest<Result<ItemResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}