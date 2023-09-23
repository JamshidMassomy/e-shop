

using System;

namespace Shop.Domain.Entities.Common
{

    public interface IGuid { }

  
    [StronglyTypedId]
    public partial struct UserId : IGuid
    {
        public static implicit operator UserId(Guid guid)
        {
            return new UserId(guid);
        }
    }
}
