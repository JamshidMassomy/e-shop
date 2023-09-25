using Ardalis.Result;
using MediatR;

namespace Shop.Application.Features.Item.DeleteItem
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, Result>
    {
        // context
        public DeleteItemHandler() { }

        public Task<Result> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    
}
