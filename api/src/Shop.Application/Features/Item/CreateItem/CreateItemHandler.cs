using MediatR;
using Ardalis.Result;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Item.CreateItem
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, Result<ItemResponse>>
    {

        // private readonly IContext _context;

        public CreateItemHandler() { }

        public Task<Result<ItemResponse>> Handle(CreateItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

       
    }
}
