using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.Cpf).IsUnique();  /*Cpf será unico*/
            builder.Property(t => t.Cpf).IsRequired().HasMaxLength(14);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(60);

            builder.Property(t => t.Phone).IsRequired().HasMaxLength(20);

            builder.Property(t => t.Email).IsRequired().HasMaxLength(20);


            /*Sale 1:N.*/

            builder.HasMany(t => t.SaleCl).WithOne(t => t.ClientSale).HasForeignKey(t =>
            t.ClienteId);
        }
    }
}