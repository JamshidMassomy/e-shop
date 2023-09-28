using Ardalis.Result;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;

namespace Shop.Application.Features.Item.UpdateItem
{
    internal class UpdateItemRequestHandler : IRequestHandler<UpdateItemRequest, Result<ItemResponse>>
    {
        private readonly IContext _context;
        public UpdateItemRequestHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Result<ItemResponse>> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            var originalItem = await _context.Items
          .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (originalItem == null) return Result.NotFound();

            originalItem.Name = request.Name;
            originalItem.Description = request.Description;
            originalItem.Price = request.Price;
            originalItem.Quantity = request.Quantity;
            _context.Items.Update(originalItem);
            await _context.SaveChangesAsync(cancellationToken);
            return originalItem.Adapt<ItemResponse>();
        }
    }
}
