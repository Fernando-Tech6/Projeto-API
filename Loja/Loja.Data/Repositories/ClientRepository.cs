using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Loja.Domain.Validate;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class ClientRepository : BaseEntity, IBaseRepository<ClientEntity>
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Clients.SingleOrDefaultAsync(t => t.Id == id);
                
                if(user != null) 
                {
                    _context.Clients.Remove(user);
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

        public async Task<ClientEntity> InsertAsync(ClientEntity user)
        {
           

            try
            {  
                 var valida  = ValidaCpf.CpfValidate(user.Cpf);

                if(valida == false)
                {
                    return null;
                }
                else
                {
                    _context.Clients.Add(user);
                    await _context.SaveChangesAsync();
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public async Task<IEnumerable<ClientEntity>> SelectAsync()
        {
            try
            {      
                return await _context.Clients
                .Include(t => t.AdressCl)
                .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClientEntity> SelectIdAsync(int id)
        {
            try
            {
                return await _context.Clients
                .Include(t => t.AdressCl)
                .SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClientEntity> UpdateAsync(ClientEntity user)
        {
            try
            {
                var up = await _context.Clients.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));

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