

namespace Shop.Application.Features.Auth
{
    public record Jwt
    {
        public string Token { get; init; } = null!;
        public DateTime ExpDate { get; init; }
    }
}
