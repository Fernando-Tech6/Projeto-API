using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class ProductRepository : BaseEntity, IProductRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

    

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Products.SingleOrDefaultAsync(t => t.Id.Equals(id));

                if (user != null)
                {
                    _context.Products.Remove(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductEntity> InsertAsync(ProductEntity user)
        {
            try
            {
                if(user.StockP.Quantity > 0)
                {
                    throw new ArithmeticException();
                }
                _context.Products.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public async Task<IEnumerable<ProductEntity>> SelectAsync()
        {
            try
            {
                return await _context.Products
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<IEnumerable<ProductEntity>> SelectAsyncAsc()
        {
            try
            {  /*lista produtos por ordem crescentes*/
                return await _context.Products
                .OrderBy(t => t.Name)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public async Task<IEnumerable<ProductEntity>> SelectAsyncDesc()
        {
            try
            {  /*Lista produtos por odem decrescente*/
                return await _context.Products
                .OrderByDescending(t => t.Name)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        

        public async Task<ProductEntity> SelectIdAsync(int id)
        {
            try
            {
                return await _context.Products.SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ProductEntity> Busca(string nome)
        {
            try
            {   /*para realizar a busca do produto por nome, comparar se os nomes são iguais*/
                var busca = await _context.Products.SingleOrDefaultAsync(t => t.Name.ToLower() == nome.ToLower());
                if(busca != null)
                {
                    return busca;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity user)
        {
            try
            {
                var up = await _context.Products.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));
               

                if (up == null)
                {
                    return null;
                }
                else
                {
                    _context.Entry(up).CurrentValues.SetValues(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}