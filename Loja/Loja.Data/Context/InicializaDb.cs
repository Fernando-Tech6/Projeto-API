using System.Linq;
using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Context
{
    public class InicializaDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            /*REALIZAR TESTE COM ANY()*/
            if(context.Users.Any())
            {
                return;
            }

            if(context.Products.Any())
            {
                return;
            }

            /*User*/
            var user = new UserEntity[]
           {
                new UserEntity{Username = "Fernando", Password = "f123456", Role = "store"},
                new UserEntity{Username = "Nando", Password = "f123456", Role = "client"}
           };

            foreach (var item in user)
            {
                context.Users.Add(item);
            }


            /*Endereço*/

            var address = new AddressEntity[]
            {
                new AddressEntity {PublicArea = "Rua do ouvidor", Number = 55,Complement = "Ap 125", Code = "11699-879",
                District = "Sobral", City = "Fortaleza", State = "Ceara"},

                new AddressEntity {PublicArea = "Alameda das Flores", Number = 185,Complement = "Casa", Code = "236541-965",
                District = "Campos", City = "Alto", State = "Sao Paulo"},

                new AddressEntity {PublicArea = "Rua nova", Number = 10,Complement = "Condominio", Code = "233694-155",
                District = "Jardim", City = "Sorocaba", State = "Sao Paulo"}

            };

            foreach (var item in address)
            {
                context.Addresses.Add(item);
            }



            /*Clientes*/

            var clients = new ClientEntity[]
            {
                new ClientEntity {Cpf = "076.713.684-58", Name = "Kenobi", Phone = "97556231",
                Email = "kenobi@jedi.com", AdressCl = address[0]},

                 new ClientEntity {Cpf = "080.279.564-12", Name = "Anakin", Phone = "9663312",
                Email = "anakin@sith.com", AdressCl = address[1]},

                new ClientEntity {Cpf = "058.423.644-17", Name = "Fett", Phone = "81223694",
                Email = "fett@manda.com", AdressCl = address[2]}

            };

            foreach (var item in clients)
            {
                context.Clients.Add(item);
            }


            /*Fornecedor*/

            var provider = new ProviderEntity[]
            {
                 new ProviderEntity {Cnpj = "00.776.574/0001-56", Name = "Light Company", Phone = "97556231",
                Email = "light@jedi.com", AdressPr = address[0]},

                 new ProviderEntity {Cnpj = "09.346.601/0001-25", Name = "Mustafar S.A", Phone = "9663312",
                Email = "mustafar@sith.com", AdressPr = address[1]},

                new ProviderEntity {Cnpj = "61.186.680/0001-74", Name = "Capacetes LTDA", Phone = "81223694",
                Email = "capacetes@manda.com", AdressPr = address[2]}

            };

            foreach (var item in provider)
            {
                context.Providers.Add(item);
            }


            /*Estoque*/

            var stocks = new StockEntity[]
            {
                new StockEntity  {Quantity = 10, Value = 3500m, ChangeValue = true},
                new StockEntity  {Quantity = 50, Value = 2500m, ChangeValue = true},
                new StockEntity  {Quantity = 500, Value = 797.0m, ChangeValue = true}
            };

            foreach (var item in stocks)
            {
                context.Stocks.Add(item);
            }


            /*Produtos*/

            var product = new ProductEntity[]
            {
                new ProductEntity {Name = "computador", Description = "Intel I5",
                Unity = "UN", StockP = stocks[0], InStock = true},

                new ProductEntity {Name = "tablet", Description = "Apple",
                Unity = "UN", StockP = stocks[1], InStock = true},

                new ProductEntity {Name = "mouse", Description = "Gamer",
                Unity = "UN", StockP = stocks[2] ,InStock = true},

            };

            foreach (var item in product)
            {
                context.Products.Add(item);
            }


               /*Compra*/

            var buys = new BuyEntity[]
            {
                new BuyEntity {ProviderBuy = provider[0], Quantity = 150, StockBuy = stocks[0], Value = 3000m},
                new BuyEntity {ProviderBuy = provider[1], Quantity = 180, StockBuy = stocks[1], Value = 2000m},
                new BuyEntity {ProviderBuy = provider[2], Quantity = 100, StockBuy = stocks[2], Value = 700m}

            };

            foreach (var item in buys)
            {
                context.Buys.Add(item);
            }

            /*Venda*/

            var sales = new SaleEntity[]
            {
                new SaleEntity {Quantity = 5, ClientSale = clients[0], SaleSt = stocks[0], Value = 3550m, Delivered = false},
                new SaleEntity {Quantity = 10, ClientSale = clients[1], SaleSt = stocks[1], Value = 2500m, Delivered = false},
                new SaleEntity {Quantity = 100, ClientSale = clients[2], SaleSt = stocks[2], Value = 797m, Delivered = false},

            };

            foreach (var item in sales)
            {
                context.Sales.Add(item);
            }

            context.SaveChanges();

        }
    }
}
