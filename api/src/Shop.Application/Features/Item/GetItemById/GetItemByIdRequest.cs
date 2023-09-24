using Ardalis.Result;
using MediatR;

namespace Shop.Application.Features.Item.GetItemById
{
    public record GetItemByIdRequest(int Id): IRequest<Result<ItemResponse>>;
}
