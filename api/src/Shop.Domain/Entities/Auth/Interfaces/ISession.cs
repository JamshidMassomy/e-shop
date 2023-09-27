using Shop.Domain.Entities.Common;

namespace Shop.Domain.Entities.Auth.Interfaces
{
    public interface ISession
    {
        // public UserId UserId { get; }

        public DateTime Now { get; }
    }
}
