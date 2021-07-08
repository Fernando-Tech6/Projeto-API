using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{      
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(60);

            builder.Property(t => t.Unity).IsRequired().HasMaxLength(8);

            builder.Property(t => t.Description).HasMaxLength(80); 

        }
    }
}
