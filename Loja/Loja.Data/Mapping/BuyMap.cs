using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{
    public class BuyMap : IEntityTypeConfiguration<BuyEntity>
    {
        public void Configure(EntityTypeBuilder<BuyEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Quantity).IsRequired().HasMaxLength(10);
            builder.Property(t => t.Value).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}