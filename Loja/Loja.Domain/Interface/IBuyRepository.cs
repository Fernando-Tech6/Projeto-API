using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface
{
    public interface IBuyRepository
    {    /*Só terá Get e Post*/
         Task<BuyEntity> InsertAsync(BuyEntity user); 
         Task<BuyEntity> SelectIdAsync(int id);
         Task<IEnumerable<BuyEntity>> SelectAsync();
    }
}