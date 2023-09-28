using Ardalis.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;

namespace Shop.Application.Features.Item.DeleteItem
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, Result>
    {
        private readonly IContext _context;

        public DeleteItemHandler(IContext context) {
            this._context = context;
        }

        public async Task<Result> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item is null) return Result.NotFound();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
    
}
