using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class BuyService : IBuyService
    {
        private readonly IBuyRepository _repository;

        public BuyService(IBuyRepository repository)
        {
            _repository = repository;
        }

        public Task<BuyEntity> Get(int id)
        {
            return _repository.SelectIdAsync(id);
        }

        public Task<IEnumerable<BuyEntity>> GetAll()
        {
            return _repository.SelectAsync();
        }

        public Task<BuyEntity> Post(BuyEntity user)
        {
            return _repository.InsertAsync(user);
        }

    }
}