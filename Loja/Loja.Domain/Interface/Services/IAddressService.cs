using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IAddressService
    {
         Task<AddressEntity> Get(int id);
         Task<IEnumerable<AddressEntity>> GetAll();
         Task<AddressEntity> Post(AddressEntity user);
         Task<AddressEntity> Patch(AddressEntity user);
         Task<bool> Delete(int id);
    }
}