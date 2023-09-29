using Ardalis.Result;
using MediatR;
using Shop.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace Shop.Application.Features.Item.UpdateItem
{
    public record UpdateItemRequest: IRequest<Result<ItemResponse>>
    {
        [JsonIgnore]
        public ItemId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
