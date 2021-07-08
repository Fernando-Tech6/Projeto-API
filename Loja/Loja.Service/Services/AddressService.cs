using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class AddressService : IAddressService
    {
        private readonly IBaseRepository<AddressEntity> _repository;

        public AddressService(IBaseRepository<AddressEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AddressEntity> Get(int id)
        {
            return await  _repository.SelectIdAsync(id);
        }

        public async Task<IEnumerable<AddressEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<AddressEntity> Patch(AddressEntity user)
        {
            return await _repository.UpdateAsync(user);
        } 

        public async Task<AddressEntity> Post(AddressEntity user)
        {
            return await _repository.InsertAsync(user);
        }
    }
}