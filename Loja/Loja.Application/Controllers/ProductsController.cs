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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "store")]
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
       [Route("asc")]
       [Authorize(Roles = "store, client")]
        public async Task<IActionResult> GetAllAsc()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var get = await _service.GetAllAsc();
                return Ok(get);
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }

        }

       [HttpGet]
       [Route("desc")]
       [Authorize(Roles = "store, client")]
        public async Task<IActionResult> GetAllAscDesc()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var get = await _service.GetAllDesc();
                return Ok(get);
            }
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }

        }

        [HttpGet]
        [Route("{id}", Name = "product")]
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
            catch(ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Não Encontrado"});
            }
        }


        [HttpGet]
        [Route("forname/{name}")]
        [Authorize(Roles = "store, client")]
        public async Task<IActionResult> GetName(string name)
        {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var getname = await _service.Busca(name);
                
                if(getname != null)
                {
                    return Ok(getname);
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


        [HttpPost]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> Post([FromBody] ProductEntity product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Post(product);

                if(user != null)
                {
                    return Created(new Uri(Url.Link("product", new {id = user.Id})), user);
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
            catch(ArithmeticException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Quantidade deve ter valor zero"});
            }
        }

        [HttpPatch]
        [Authorize(Roles = "store")]
        public async Task<IActionResult> Patch([FromBody] ProductEntity product)
        {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _service.Patch(product);
                
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
        [Authorize(Roles = "store")]
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