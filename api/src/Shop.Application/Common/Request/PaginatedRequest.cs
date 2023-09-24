using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Request
{
    public record PaginatedRequest
    {
        public int CurrentPage { get; init; } = 1;

        public int PageSize { get; init; } = 10;
    }
}
