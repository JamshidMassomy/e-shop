using Mapster;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Response;

namespace Shop.Application.Features.Item.GetAllItem
{
    public class AllItemHandler : IRequestHandler<AllItemRequest, PaginatedList<ItemResponse>>
    {
        private readonly IContext _context;

        public AllItemHandler(IContext context) { 
            this._context = context;
        }

        public async Task<PaginatedList<ItemResponse>> Handle(AllItemRequest request, CancellationToken cancellationToken)
        {
            var items = _context.Items.Select(item => 
               new ItemResponse 
               { 
                   Id = item.Id ,
                   Name = item.Name,
                   Price = item.Price,
                   Description = item.Description
               });


            return await items.ProjectToType<ItemResponse>() 
                .OrderBy(x => x.Name)
                .ToPaginatedListAsync(request.CurrentPage, request.PageSize);

        }
    }
}

