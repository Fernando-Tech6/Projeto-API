using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public Task<SaleEntity> Get(int id)
        {
            return _repository.SelectIdAsync(id);
        }

        public Task<IEnumerable<SaleEntity>> GetAll()
        {
            return _repository.SelectAsync();
        }

        public Task<SaleEntity> Patch(SaleEntity user)
        {
            return _repository.UpdateAsync(user);
        }

        public Task<SaleEntity> PatchConfirm(SaleEntity user)
        {
            return _repository.Confirm(user);
        }

        public Task<SaleEntity> Post(SaleEntity user)
        {
            return _repository.InsertAsync(user);
        }
    }
}