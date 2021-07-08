using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IStockService
    {
         Task<StockEntity> Get(int id);
         Task<IEnumerable<StockEntity>> GetAll(); 
         Task<IEnumerable<StockEntity>> GetAllClient();   

         Task<StockEntity> Patch(StockEntity user);
    }
}