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
    public class ProviderRepository : BaseEntity, IBaseRepository<ProviderEntity>
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user =  await _context.Providers.SingleOrDefaultAsync(t => t.Id.Equals(id));

                if(user != null)
                {
                    _context.Providers.Remove(user);
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

        public async Task<ProviderEntity> InsertAsync(ProviderEntity user)
        {
            try
            {
                /*Verificar se o cnpj é valido*/
                 var valida  = ValidaCnpj.CnpjValidate(user.Cnpj);

                if(valida == false)
                {
                    return null;
                }
                else
                {
                    _context.Providers.Add(user);
                    await _context.SaveChangesAsync();
                }

         
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public async Task<IEnumerable<ProviderEntity>> SelectAsync()
        {
            try
            {
                return await _context.Providers
                .Include(t => t.AdressPr)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProviderEntity> SelectIdAsync(int id)
        {
            try
            {
                return await _context.Providers
                .Include(t => t.AdressPr)
                .SingleOrDefaultAsync(t => t.Id.Equals(id));
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProviderEntity> UpdateAsync(ProviderEntity user)
        {
            try
            {
                var up = await _context.Providers.SingleOrDefaultAsync(t => t.Id.Equals(user.Id));

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