using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    backingType: StronglyTypedIdBackingType.Guid,
    converters: StronglyTypedIdConverter.SystemTextJson | StronglyTypedIdConverter.EfCoreValueConverter |
                StronglyTypedIdConverter.Default | StronglyTypedIdConverter.TypeConverter,
    implementations: StronglyTypedIdImplementations.IEquatable | StronglyTypedIdImplementations.Default)]

namespace Shop.Domain.Entities.Common
{
    public interface IGuid { }

    [StronglyTypedId]
    public partial struct ItemId : IGuid
    {
        public static implicit operator ItemId(Guid guid)
        {
            return new ItemId(guid);
        }
    }
}
