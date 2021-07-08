using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IProviderService
    {
         Task<ProviderEntity> Get(int id);
         Task<IEnumerable<ProviderEntity>> GetAll();
         Task<ProviderEntity> Post(ProviderEntity user);
         Task<ProviderEntity> Patch(ProviderEntity user);
         Task<bool> Delete(int id);
    }
}