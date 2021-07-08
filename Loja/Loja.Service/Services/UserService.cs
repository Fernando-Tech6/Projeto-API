using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.RegisterAsync(user);
        }

        public async Task<UserEntity> PostLogin(UserEntity user)
        {
            return await _repository.LoginAsync(user);
        }
    }
}