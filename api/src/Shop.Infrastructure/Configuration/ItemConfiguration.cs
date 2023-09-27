using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Common;
using Shop.Domain.Entities.Item;

namespace Shop.Infrastructure.Configuration
{
    public class ItemConfiguration: IEntityTypeConfiguration<Item>
    {

        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion<ItemId.EfCoreValueConverter>();
           
        }
    }
}
