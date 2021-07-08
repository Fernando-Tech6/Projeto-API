using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IBaseRepository<ProviderEntity> _repository;

        public ProviderService(IBaseRepository<ProviderEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProviderEntity> Get(int id)
        {
            return await _repository.SelectIdAsync(id);
        }

        public async Task<IEnumerable<ProviderEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ProviderEntity> Patch(ProviderEntity user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<ProviderEntity> Post(ProviderEntity user)
        {
            return await _repository.InsertAsync(user);
        }
    }
}