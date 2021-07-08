using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{
    public class SaleMap : IEntityTypeConfiguration<SaleEntity>
    {
        public void Configure(EntityTypeBuilder<SaleEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Quantity).IsRequired().HasMaxLength(8);
            builder.Property(t => t.Value).HasColumnType("decimal(18,2)").IsRequired();
            
        }
    }
}