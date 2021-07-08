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
    public class StocksController : ControllerBase
    {
        private readonly IStockService _service;

        public StocksController(IStockService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var get = await _service.GetAll();
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }

        [HttpGet]
        [Route("client")]
        [Authorize(Roles = "store, client")]
        public async Task<IActionResult> GetAllClient()
        {    /*Irá servir para o cliente verificar a lista de produtos*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var get = await _service.GetAllClient();
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }

        [HttpGet]
        [Route("{id}", Name = "stock")]
        [Authorize(Roles = "store, client")]
        public async Task<IActionResult> GetId(int id)
        {
            if (!ModelState.IsValid)
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
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }

        [HttpPatch]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> Patch([FromBody] StockEntity stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Patch(stock);

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
