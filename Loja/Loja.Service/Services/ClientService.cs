using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<ClientEntity> _repository;

        public ClientService(IBaseRepository<ClientEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ClientEntity> Get(int id)
        {
            return await  _repository.SelectIdAsync(id);
        }

        public async Task<IEnumerable<ClientEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ClientEntity> Patch(ClientEntity user)
        {
             return await _repository.UpdateAsync(user);
        }

        public async Task<ClientEntity> Post(ClientEntity user)
        {
            return await _repository.InsertAsync(user);
        }
    }
}