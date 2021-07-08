using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface ISaleService
    {
         Task<SaleEntity> Get(int id);
         Task<IEnumerable<SaleEntity>> GetAll();
         Task<SaleEntity> Post(SaleEntity user);
         Task<SaleEntity> Patch(SaleEntity user);
         Task<SaleEntity> PatchConfirm(SaleEntity user);

         
    }
}