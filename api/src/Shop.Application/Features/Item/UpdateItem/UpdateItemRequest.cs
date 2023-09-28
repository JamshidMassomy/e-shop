using Ardalis.Result;
using MediatR;
using Shop.Domain.Entities.Common;

namespace Shop.Application.Features.Item.UpdateItem
{
    internal class UpdateItemRequest: IRequest<Result<ItemResponse>>
    {
        public ItemId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
