using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class StockRepository : BaseEntity, IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<StockEntity>> SelectAsync()
        {
            try
            {
                return await _context.Stocks
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<StockEntity>> SelectAsyncClient()
        {
             try
            {
                return await _context.Stocks
                .Include(t => t.ProductSt)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StockEntity> SelectIdAsync(int id)
        {
            try
            {
                return await _context.Stocks
                .SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StockEntity> UpdateAsync(StockEntity user)
        {
            try
            {
                var up = await _context.Stocks.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));    

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