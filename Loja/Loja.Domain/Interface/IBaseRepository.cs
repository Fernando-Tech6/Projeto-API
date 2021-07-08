using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface
{
    public interface IBaseRepository<T>
    {  /*Será criada para obrigar a implementação de metodos que irão servir a todas as entidade.
        Será utilizado apenas para entidade que implementarem um CRUD completo.
        */
         
         Task<T> InsertAsync(T user); 
         Task<T> UpdateAsync(T user);
         Task<bool> DeleteAsync(int id);
         Task<T> SelectIdAsync(int id);
         Task<IEnumerable<T>> SelectAsync();
         
    }
}