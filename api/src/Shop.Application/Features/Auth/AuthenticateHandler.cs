using Ardalis.Result;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Auth;
using Shop.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Application.Features.Auth
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, Result<Jwt>>
    {
        //private readonly IContext _context;

        private readonly TokenConfiguration _appSettings;

        public AuthenticateHandler(IOptions<TokenConfiguration> appSettings /*IContext context*/)
        {
           // _context = context;
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
            /*
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Security.Encrypt(AppSettings.appSettings.JwtEmailEncryption,user.email)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.appSettings.JwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(String.Empty,
              String.Empty,
              claims,
              expires: DateTime.Now.AddSeconds(55 * 60),
              signingCredentials: creds);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
            */


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