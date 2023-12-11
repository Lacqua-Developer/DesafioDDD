using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using Catalogo.Application.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogosDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoria : ControllerBase
    {
        // GET: api/<Categoria>
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return new List<Categoria>();
        }

        // GET api/<Categoria>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Categoria>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Categoria>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Categoria>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
