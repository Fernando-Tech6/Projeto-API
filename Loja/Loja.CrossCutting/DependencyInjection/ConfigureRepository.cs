using Loja.Data.Repositories;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection service)
        {
            service.AddScoped(typeof(IBaseRepository<AddressEntity>), typeof(AddressRepository));
            service.AddScoped(typeof(IBaseRepository<ClientEntity>),typeof(ClientRepository));
            service.AddScoped(typeof(IBaseRepository<ProviderEntity>),typeof(ProviderRepository));
            service.AddScoped(typeof(IProductRepository),typeof(ProductRepository));
            service.AddScoped(typeof(IStockRepository),typeof(StockRepository));
            service.AddScoped(typeof(ISaleRepository),typeof(SaleRepository));
            service.AddScoped(typeof(IBuyRepository),typeof(BuyRepository));
            service.AddScoped(typeof(IUserRepository),typeof(UserRepository));

        }
    }
}