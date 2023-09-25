using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace Shop.Application.Features.Auth
{
    public record AuthenticateRequest : IRequest<Result<Jwt>>
    {
        public AuthenticateResult RequestResult { get; init; } = null!;
    }

   
}
