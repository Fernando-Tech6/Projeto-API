using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface
{
    public interface ISaleRepository
    {
         Task<SaleEntity> InsertAsync(SaleEntity user); 
         Task<SaleEntity> SelectIdAsync(int id);
         Task<IEnumerable<SaleEntity>> SelectAsync();
         Task<SaleEntity> UpdateAsync(SaleEntity user);
         Task<SaleEntity> Confirm(SaleEntity user);

    }
}