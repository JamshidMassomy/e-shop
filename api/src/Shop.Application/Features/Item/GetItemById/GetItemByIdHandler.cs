using MediatR;
using Ardalis.Result;

namespace Shop.Application.Features.Item.GetItemById
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, Result<ItemResponse>>
    {
        // context here
        public Task<Result<ItemResponse>> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
