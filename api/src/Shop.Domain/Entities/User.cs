using MassTransit;
using Shop.Domain.Entities.Common;

namespace Shop.Domain.Entities
{
    public class User : Entity<UserId>
    {
        public override UserId Id { get; set; } = NewId.NextGuid();

        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
