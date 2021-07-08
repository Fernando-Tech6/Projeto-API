using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{
    public class ProviderMap : IEntityTypeConfiguration<ProviderEntity>
    {
        public void Configure(EntityTypeBuilder<ProviderEntity> builder)
        {
            builder.HasKey(t => t.Id);


            builder.HasIndex(t => t.Cnpj).IsUnique(); /*cnpj será unico*/
            builder.Property(t => t.Cnpj).IsRequired().HasMaxLength(18);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(60);

            builder.Property(t => t.Phone).IsRequired().HasMaxLength(20);

            builder.Property(t => t.Email).IsRequired().HasMaxLength(60);

            /*buy 1:N.*/

            builder.HasMany(t => t.BuyPro).WithOne(t => t.ProviderBuy).HasForeignKey(
             t => t.ProviderId );

        }
    }
}