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

            var claimsIdentity = new ClaimsIdentity(claimEnumerable, "custom");


            /*
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower(), cancellationToken);
            if (user == null || !BC.Verify(request.Password, user.Password))
            {
                return Result.Invalid(new List<ValidationError> {
                new ValidationError
                {
                    Identifier = $"{nameof(request.Password)}|{nameof(request.Email)}",
                    ErrorMessage = "Username or password is incorrect"
                }
            });
            }

            */



            /*var claims = new ClaimsIdentity(new Claim[]
            {
                // new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                // new(ClaimTypes.Email, user.Email),
                // new(ClaimTypes.Role, user.Role)

                 // new(ClaimTypes.NameIdentifier, request.Claims.FirstOrDefaultAsync(x => x.),
                 //new(ClaimTypes.Email, user.Email),
                 //new(ClaimTypes.Role, user.Role)

            });
            */

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expDate = DateTime.UtcNow.AddHours(1);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = expDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _appSettings.Audience,
                Issuer = _appSettings.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // var tokenString = tokenHandler.WriteToken(token);

            return new Jwt
            {
                Token = tokenHandler.WriteToken(token),
                ExpDate = expDate
            };
            
          
        }
    }
}
