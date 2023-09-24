using MediatR;
using Shop.Application.Response

namespace Shop.Application.Features.Item.GetAllItem
{
    internal class GetAllItemHandler : IRequestHandler<GetAllItemRequest, PaginatedList<ItemResponse>>
    {
        public Task<PaginatedList<ItemResponse>> Handle(GetAllItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
