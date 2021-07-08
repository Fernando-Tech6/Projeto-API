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
    [Authorize(Roles = "client")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _service;

        public SalesController(ISaleService service)
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
        [Route("{id}", Name = "sale")]
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
        public async Task<IActionResult> Post([FromBody] SaleEntity sale)
        {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
              
                var user = await _service.Post(sale);

                if(user != null)
                {    
                    return Created(new Uri(Url.Link("sale", new {id = user.Id})), user);
                }
                else
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {msg = "Não encontrado"});
                }
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Quantidade no estoque inferior a solicitada na venda"  });
            }
            catch(InvalidOperationException)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Valor inferior ao do estoque ou o valor do estoque não foi alterado"  });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] SaleEntity sale)
        {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Patch(sale);

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
        
        [HttpPatch]
        [Route("confirm")]
        public async Task<IActionResult> Confir([FromBody] SaleEntity sale)
        {             /*Será utilizado para confirmar a entrega do produto pelo cliente*/
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.PatchConfirm(sale);

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
        
    }
}