using System;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //retorna um 400
            }

            try
            {
                var get = await _service.GetAll();
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }

        [HttpGet]
        [Route("{id}", Name = "client")]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> GetId(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            try
            {
                var get = await _service.Get(id);
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ClientEntity client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var user = await _service.Post(client);

                if (user != null)
                {
                    return Created(new Uri(Url.Link("client", new {id = user.Id})), user);
                }
                else
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {msg = "CPF Inválido"});
                }
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> Del(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var delete = await _service.Delete(id);

                if (delete == false)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { msg = "Não Encontrado" });
                }
                else
                {
                    Response.StatusCode = 410;
                    return new ObjectResult(new { msg = "Deletado com sucesso" });
                }
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }



        [HttpPatch]
        [Authorize(Roles = "store, client")]
        public async Task<IActionResult> Patch([FromBody] ClientEntity client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Patch(client);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { msg = "Não Encontrado" });
                }
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }
    }
}