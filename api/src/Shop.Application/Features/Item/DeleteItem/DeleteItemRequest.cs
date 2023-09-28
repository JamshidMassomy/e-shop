using Ardalis.Result;
using MediatR;
using Shop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Item.DeleteItem
{
    public record DeleteItemRequest(ItemId Id) : IRequest<Result>;
}
