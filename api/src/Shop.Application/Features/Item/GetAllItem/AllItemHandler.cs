using MediatR;
using Shop.Application.Response;

namespace Shop.Application.Features.Item.GetAllItem
{
    internal class AllItemHandler : IRequestHandler<AllItemRequest, PaginatedList<ItemResponse>>
    {
        public Task<PaginatedList<ItemResponse>> Handle(AllItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
