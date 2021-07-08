using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface
{
    public interface IUserRepository
    {   /*Criado para uso de autenticação de usuario*/
         Task<UserEntity> RegisterAsync(UserEntity user); 
         Task<UserEntity> LoginAsync(UserEntity user); 
         Task<bool> DeleteAsync(int id);
    }
}