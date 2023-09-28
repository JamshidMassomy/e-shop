using Ardalis.Result;
using MediatR;
using Shop.Domain.Entities.Common;

namespace Shop.Application.Features.Item.GetItemById
{
    public record GetItemByIdRequest(ItemId Id): IRequest<Result<ItemResponse>>;
}
