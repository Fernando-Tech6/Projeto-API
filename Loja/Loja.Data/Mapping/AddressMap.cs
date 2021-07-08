using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.PublicArea).IsRequired().HasMaxLength(100);

            builder.Property(t => t.Number).IsRequired().HasMaxLength(6);

            builder.Property(t => t.Complement).IsRequired().HasMaxLength(60);

            builder.Property(t => t.Code).IsRequired().HasMaxLength(20);

            builder.Property(t => t.District).IsRequired().HasMaxLength(60);

            builder.Property(t => t.City).IsRequired().HasMaxLength(60);

            builder.Property(t => t.State).IsRequired().HasMaxLength(60);

            /*Relacionamento 1:N*/
            builder.HasOne(t => t.ClientAd).WithOne(t => t.AdressCl).HasForeignKey<ClientEntity>(t => 
            t.AdressId);
             builder.HasOne(t => t.ProviderAd).WithOne(t => t.AdressPr).HasForeignKey<ProviderEntity>(t => 
             t.AdressId);
        }
    }
}