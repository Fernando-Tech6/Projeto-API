using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mapping
{
    public class StockMap : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> builder)
        {
            builder.HasKey(t => t.Id);

           builder.Property(t => t.Quantity).IsRequired().HasMaxLength(8);
           
           builder.Property(t => t.Value).HasColumnType("decimal(18,2)").IsRequired();

            /*1:N Venda*/
            builder.HasMany(t => t.SaleSt).WithOne(t => t.SaleSt).HasForeignKey(
               t => t.StockId);

                /*1:N Compra*/
               builder.HasMany(t => t.BuySt).WithOne(t => t.StockBuy).HasForeignKey(
               t => t.StockId);
                
                /*1: 1 Produto*/
               builder.HasOne(t => t.ProductSt).WithOne(t => t.StockP).HasForeignKey<ProductEntity>(
                   t => t.StockId);
               
        }
    }
}