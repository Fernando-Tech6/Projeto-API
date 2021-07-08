using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IProductService 
    {
          Task<ProductEntity> Get(int id);
         Task<IEnumerable<ProductEntity>> GetAll();
         Task<IEnumerable<ProductEntity>> GetAllAsc();
         Task<IEnumerable<ProductEntity>> GetAllDesc();

         Task<ProductEntity> Post(ProductEntity user);
         Task<ProductEntity> Patch(ProductEntity user);
         Task<bool> Delete(int id);

         Task<ProductEntity> Busca(string nome);

    }
}