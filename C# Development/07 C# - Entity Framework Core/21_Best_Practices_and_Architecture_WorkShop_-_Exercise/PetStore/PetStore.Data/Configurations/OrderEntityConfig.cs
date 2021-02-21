using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class OrderEntityConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(x => x.Town)
                .HasMaxLength(40)
                .IsUnicode(true);

            builder
                .Property(x => x.Address)
                .HasMaxLength(70)
                .IsUnicode(true);

            builder.Ignore(x => x.TotalPrice);
        }
    }
}
