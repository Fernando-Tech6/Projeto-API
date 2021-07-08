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
    [Authorize(Roles = "store")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService  _service;

        public ProvidersController(IProviderService  service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var get = await _service.GetAll();
                return Ok(get);
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }

        }


        [HttpGet]
        [Route("{id}", Name = "provider")]
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
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }

        [HttpPost]
         public async Task<IActionResult> Post([FromBody] ProviderEntity provider)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Post(provider);

                if(user != null)
                {
                    return Created(new Uri(Url.Link("provider", new {id = user.Id})), user);
                }
                else
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {msg = "CNPJ Inválido"});
                }
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }
        
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] ProviderEntity provider)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Patch(provider);

                if(user != null)
                {
                    return Ok(user);
                }
                else
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {msg = "Não Encontrado"});
                }
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Del(int id)
        {
            if (!ModelState.IsValid)
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