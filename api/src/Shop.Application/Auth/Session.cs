
using Shop.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using ISession = Shop.Domain.Entities.Auth.Interfaces.ISession;


namespace Shop.Application.Auth
{
    public class Session : ISession
    {
       //  public UserId UserId { get; private init; }

        public DateTime Now => DateTime.Now;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

            /*if (nameIdentifier != null)
            {
                UserId = new Guid(nameIdentifier.Value);
            }
            if (nameIdentifier != null)
            {
                if (Guid.TryParse(nameIdentifier.Value, out Guid userId))
                {
                    UserId = userId;
                }
                else
                {
                    // Handle the case where the claim value is not a valid Guid
                    // You can log an error or take other appropriate actions
                }
            }
            */
        }

    }
}
