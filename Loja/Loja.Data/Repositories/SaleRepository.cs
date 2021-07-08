using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class SaleRepository : BaseEntity, ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<SaleEntity> Confirm(SaleEntity user)
        {      /*Será utilizada para confirmar o recebimento*/
            try 
            {
               var up = await _context.Sales.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));

               if (up == null)
               {
                   return null;
               }
               else
               {    /*Ao atualizar ele irá atualizar a entrega para true*/
                    user.Quantity = up.Quantity;
                    user.ClienteId = up.ClienteId;
                    user.StockId = up.StockId;
                    user.Delivered = true;
                   
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

        public async Task<SaleEntity> InsertAsync(SaleEntity user)
        {
            try 
            {  /*Realizado uma busca para verificar o mesmo id do estoque.
                Se o quantidade for menor ele irá lançar uma excessão.
                Se a quantidade for maior ele irá realizar a subtração e chamar 
                o metodo para atualizar.
                */
          

                var busca = await _context.Stocks
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == user.StockId);

                if( user.Value < busca.Value || busca.ChangeValue == false)
                {   /*Criado para validar a venda se não realizar a mudança do valor não irá comprar,
                     e se o valor da venda for inferior ao do estoque também*/
                    throw new InvalidOperationException();
                }

                if (busca.Quantity < user.Quantity)
                {

                    throw new ArgumentException();
                }

                int sub = busca.Quantity - user.Quantity;
     
                var stock = new StockEntity();
                stock.Id = user.StockId;
                stock.Quantity = sub;
                stock.Value = busca.Value;

                var change = new StockRepository(_context);
                await change.UpdateAsync(stock);

                _context.Sales.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return user;
        }

        public async Task<IEnumerable<SaleEntity>> SelectAsync()
        {
            try 
            {
               return await _context.Sales
               .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaleEntity> SelectIdAsync(int id)
        {
            try 
            {
               return await _context.Sales
               .SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaleEntity> UpdateAsync(SaleEntity user)
        {
            try 
            {
               var up = await _context.Sales.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));
                
               if (up == null)
               {
                   return null;
               }
               else
               {
                    user.Delivered = false;
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