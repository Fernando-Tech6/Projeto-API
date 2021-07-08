using System.Linq;
using Loja.Data.Mapping;
using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<ProviderEntity> Providers { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }

        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<BuyEntity> Buys { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            /*Colocando um comportamento ao excluir um item que tenha relacionamento com outro*/
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            /*Ao Criar para o banco de dados irá implementar as obrigatoriedades*/

            builder.Entity<ProductEntity>(new ProductMap().Configure);

            builder.Entity<ClientEntity>(new ClientMap().Configure);
            
            builder.Entity<ProviderEntity>(new ProviderMap().Configure);

            builder.Entity<StockEntity>(new StockMap().Configure);

            builder.Entity<SaleEntity>(new SaleMap().Configure);

            builder.Entity<BuyEntity>(new BuyMap().Configure);

            builder.Entity<AddressEntity>(new AddressMap().Configure);



        }

    }
}