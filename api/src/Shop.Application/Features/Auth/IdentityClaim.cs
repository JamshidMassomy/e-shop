

namespace Shop.Application.Features.Auth
{
    public record IdentityClaim
    {
        public string ClaimIssuer { get; init; } = null!;
        public string ClaimOriginalIssuer { get; init; } = null!;
        public string ClaimType { get; init; } = null!;
        public string ClaimValue { get; init; } = null!;
    }
}

