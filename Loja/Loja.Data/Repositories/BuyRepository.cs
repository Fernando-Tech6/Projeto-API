using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class BuyRepository : BaseEntity, IBuyRepository
    {
        private readonly ApplicationDbContext _context;

        public BuyRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<BuyEntity> InsertAsync(BuyEntity user)
        {
            try
            {   /*Para alterar o status de estoque ao comprar produtos*/
                var busca = await _context.Products
               .AsNoTracking()
               .SingleOrDefaultAsync(t => t.StockId.Equals(user.StockId));
                var produto = new ProductEntity();
                produto.Id = busca.Id;
                produto.StockId = busca.StockId;
                produto.Name = busca.Name;
                produto.Description = busca.Description;
                produto.Unity = busca.Unity;
                produto.InStock = true;


                var change = new ProductRepository(_context);
                await change.UpdateAsync(produto);


                /*Para Adicionar quantidade no estoque pela compra*/
                var qtd = await _context.Stocks
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id.Equals(user.StockId));

                int more = qtd.Quantity + user.Quantity;

                var novo = new StockEntity();
                novo.Id = qtd.Id;
                novo.Quantity = more;
                novo.Value = qtd.Value;
                novo.ChangeValue = false;

                  var stock = new StockRepository(_context);
                await stock.UpdateAsync(novo);

                _context.Buys.Add(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public async Task<IEnumerable<BuyEntity>> SelectAsync()
        {
            try
            {    
                return await _context.Buys
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BuyEntity> SelectIdAsync(int id)
        {
            try
            {
                return await _context.Buys
                .Include(t => t.StockBuy.ProductSt)
                .SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BuyEntity> UpdateAsync(BuyEntity user)
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
