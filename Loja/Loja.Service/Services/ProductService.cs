using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Interface.Services;

namespace Loja.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

       
        public Task<bool> Delete(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<ProductEntity> Get(int id)
        {
            return _repository.SelectIdAsync(id);
        }

        public Task<IEnumerable<ProductEntity>> GetAll()
        {
           return _repository.SelectAsync();
        }

        public Task<IEnumerable<ProductEntity>> GetAllAsc()
        {
           return _repository.SelectAsyncAsc();
        }

         public Task<IEnumerable<ProductEntity>> GetAllDesc()
        {
           return _repository.SelectAsyncDesc();
        }
        

        public Task<ProductEntity> Patch(ProductEntity user)
        {
            return _repository.UpdateAsync(user);
        }

        public Task<ProductEntity> Post(ProductEntity user)
        {
            return _repository.InsertAsync(user);
        }

         public Task<ProductEntity> Busca(string nome)
        {
           return _repository.Busca(nome);
        }

    }
}