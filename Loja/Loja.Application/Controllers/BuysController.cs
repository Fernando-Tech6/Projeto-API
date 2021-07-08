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
    public class BuysController : ControllerBase
    {
        private readonly IBuyService _service;

        public BuysController(IBuyService service)
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
        [Route("{id}", Name = "buy")]
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
        public async Task<IActionResult> Post([FromBody] BuyEntity buy)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Post(buy);
                    

                if(user != null)
                {
                    return Created(new Uri(Url.Link("buy", new {id = user.Id})), user);
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
                return new ObjectResult(new {msg = "Não Encontrado"});
            }

            
        }
    }
}