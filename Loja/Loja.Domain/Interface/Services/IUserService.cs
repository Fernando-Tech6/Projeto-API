using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interface.Services
{
    public interface IUserService
    {
         Task<UserEntity> Post(UserEntity user);
         Task<UserEntity> PostLogin(UserEntity user);
         Task<bool> Delete(int id);
    }
}