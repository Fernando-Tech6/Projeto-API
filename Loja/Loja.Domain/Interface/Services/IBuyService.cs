using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IBuyService
    {
         Task<BuyEntity> Get(int id);
         Task<IEnumerable<BuyEntity>> GetAll();
         Task<BuyEntity> Post(BuyEntity user);
         

    }
}