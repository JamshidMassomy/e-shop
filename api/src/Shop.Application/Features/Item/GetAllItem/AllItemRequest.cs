using MediatR;
using Shop.Application.Common.Request;
using Shop.Application.Response;

namespace Shop.Application.Features.Item.GetAllItem
{
    public record AllItemRequest: PaginatedRequest, IRequest<PaginatedList<ItemResponse>>
    {
    }
}
