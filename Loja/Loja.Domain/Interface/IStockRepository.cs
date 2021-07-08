using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface
{
    public interface IStockRepository
    {
         Task<StockEntity> SelectIdAsync(int id);
         Task<IEnumerable<StockEntity>> SelectAsync();
         Task<IEnumerable<StockEntity>> SelectAsyncClient();

         Task<StockEntity> UpdateAsync(StockEntity user);
    }
}