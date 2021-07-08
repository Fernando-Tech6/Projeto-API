using System;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Context;
using Loja.Domain.Entities;
using Loja.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data.Repositories
{
    public class UserRepository : BaseEntity, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var delete = await _context.Users.SingleOrDefaultAsync(t => t.Id.Equals(id));

                if(delete != null)  
                {
                    _context.Users.Remove(delete);
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

        public async Task<UserEntity> LoginAsync(UserEntity user)
        {
            try
            { /*verificar se a senha e o usuario está correto*/
                var verification = await _context.Users.Where(t => t.Username.ToLower() == user.Username.ToLower() && 
                t.Password == user.Password).FirstOrDefaultAsync();

                if(verification == null)
                {  /*Se a senha e o usurname forem invalidos retornar null
                     acionando um tratamento de erro no controller.*/
                    return null;
                }
                else
                {
                    return verification;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserEntity> RegisterAsync(UserEntity user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}