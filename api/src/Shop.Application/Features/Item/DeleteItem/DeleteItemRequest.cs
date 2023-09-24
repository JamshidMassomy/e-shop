using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Item.DeleteItem
{
    public record DeleteItemRequest(int Id) : IRequest<Result>;
}
