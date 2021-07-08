using System;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface.Services;
using Loja.Service.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterPost([FromBody] UserEntity user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var post = await _service.Post(user);
                return Ok(user);
            }
            catch(ArgumentException)
            {
                 Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserEntity user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var login = await _service.PostLogin(user);

                if(login == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {msg = "Não Encontrado ou username e senha invalidos"});
                }

                /*Gerar token*/
                var token = TokenService.GenerateToken(login);

                /*Oculta a senha*/
                 login.Password = "";
  
                /*Retornar os dados*/
                return new 
                {
                    login = login,
                    token = token
                };

            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [Authorize(Roles = "store")]  /*para remover um usuario só a loja tem acesso*/
        public async Task<IActionResult> Del(int id)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var delete = await _service.Delete(id);

                if(delete == false)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {msg = "Não Encontrado"});
                }
                else
                {
                    Response.StatusCode = 410;
                    return new ObjectResult(new {msg = "Deletado com sucesso"});
                }
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }
    }
}