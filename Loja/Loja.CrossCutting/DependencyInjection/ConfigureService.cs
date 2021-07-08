using Loja.Domain.Interface.Services;
using Loja.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddScoped<IAddressService, AddressService>();
            service.AddScoped<IClientService, ClientService>();
            service.AddScoped<IProviderService, ProviderService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ISaleService, SaleService>();
            service.AddScoped<IBuyService, BuyService>();
            service.AddScoped<IStockService, StockService>();
            service.AddScoped<IUserService, UserService>();


        }
    }
}