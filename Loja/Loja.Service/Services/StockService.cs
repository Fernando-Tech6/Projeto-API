using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class StockService : IStockService
    {     
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public Task<StockEntity> Get(int id)
        {
            return _repository.SelectIdAsync(id);
        }

        public Task<IEnumerable<StockEntity>> GetAll()
        {
            return _repository.SelectAsync();
        }

        public Task<IEnumerable<StockEntity>> GetAllClient()
        {
            return _repository.SelectAsyncClient();
        }

        public Task<StockEntity> Patch(StockEntity user)
        {
            return _repository.UpdateAsync(user);
        }
    }
}