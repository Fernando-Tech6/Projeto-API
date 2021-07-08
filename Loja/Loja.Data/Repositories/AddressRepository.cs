using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class AddressRepository : BaseEntity, IBaseRepository<AddressEntity>
    {
       private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Addresses.SingleOrDefaultAsync(t => t.Id == id);
                
                if(user != null) 
                {
                    _context.Addresses.Remove(user);
                    await _context.SaveChangesAsync();
                    return true;   
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressEntity> InsertAsync(AddressEntity user)
        {
            try
            {  
               
                _context.Addresses.Add(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public async Task<IEnumerable<AddressEntity>> SelectAsync()
        {
            try
            {     
                return await _context.Addresses.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressEntity> SelectIdAsync(int id)
        {
            try
            {
                return await _context.Addresses.SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressEntity> UpdateAsync(AddressEntity user)
        {
            try
            {
                var up = await _context.Addresses.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));

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