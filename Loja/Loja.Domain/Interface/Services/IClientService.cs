using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IClientService
    {
        
         Task<ClientEntity> Get(int id);
         Task<IEnumerable<ClientEntity>> GetAll();
         Task<ClientEntity> Post(ClientEntity user);
         Task<ClientEntity> Patch(ClientEntity user);
         Task<bool> Delete(int id);
    }
}