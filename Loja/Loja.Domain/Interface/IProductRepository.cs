using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface
{
    public interface IProductRepository
    {
         Task<ProductEntity> InsertAsync(ProductEntity user); 
         Task<ProductEntity> UpdateAsync(ProductEntity user);
         Task<bool> DeleteAsync(int id);
         Task<ProductEntity> SelectIdAsync(int id);
         Task<IEnumerable<ProductEntity>> SelectAsync();
         Task<IEnumerable<ProductEntity>> SelectAsyncAsc();
         Task<IEnumerable<ProductEntity>> SelectAsyncDesc();

         Task<ProductEntity> Busca(string nome);


    }
}