using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Application.Features.Auth
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, Result<Jwt>>
    {
        private readonly TokenConfiguration _appSettings;

        public AuthenticateHandler(IOptions<TokenConfiguration> appSettings)
        {
            _appSettings = appSettings.Value;

        }

        public async Task<Result<Jwt>> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var claims = new List<IdentityClaim>();
            IEnumerable<Claim> claimEnumerable;

            if (request.RequestResult?.Principal != null)
            {
                claims = request.RequestResult.Principal.Identities
                    .FirstOrDefault()?.Claims.Select(claim => new IdentityClaim
                    {
                        ClaimIssuer = claim.Issuer,
                        ClaimOriginalIssuer = claim.OriginalIssuer,
                        ClaimType = claim.Type,
                        ClaimValue = claim.Value
                    }).ToList();

                claimEnumerable = claims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue));
            }
            else
            {
                claimEnumerable = Enumerable.Empty<Claim>();
            }

            var claimsIdentity = new ClaimsIdentity(claimEnumerable, "custom");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expDate = DateTime.UtcNow.AddHours(1);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Subject = claimsIdentity,
                Expires = expDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _appSettings.Audience,
                Issuer = _appSettings.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new Jwt
            {
                Token = tokenString,
                ExpDate = expDate
            };
            
          
        }
    }
}