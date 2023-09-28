using MediatR;
using Ardalis.Result;
using Shop.Application.Common;

namespace Shop.Application.Features.Item.GetItemById
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, Result<ItemResponse>>
    {
        private readonly IContext _context;
        public GetItemByIdHandler(IContext context) { 
            this._context = context;
        }

        public Task<Result<ItemResponse>> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
