using MediatR;
using Ardalis.Result;
using Shop.Application.Common;

using Mapster;


namespace Shop.Application.Features.Item.CreateItem
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, Result<ItemResponse>>
    {

        private readonly IContext _context;

        public CreateItemHandler(IContext context) {
            _context = context;
        }

        public async Task<Result<ItemResponse>> Handle(CreateItemRequest request, CancellationToken cancellationToken)
        {
            var created = request.Adapt<Domain.Entities.Item.Item>();
            _context.Items.Add(created);
            await _context.SaveChangesAsync(cancellationToken);
            return created.Adapt<ItemResponse>();
            
        }

       
    }
}
