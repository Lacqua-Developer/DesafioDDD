using Catalogo.Application.UseCases;
using Catalogo.Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalogo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoria : ControllerBase
    {

        private readonly IRepositories<Categoria> _repository;

        public Categoria(IRepositories<Categoria> rep)
        {
            _repository = rep;
        }
        // GET: api/<Categoria>
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return _repository.Get();
        }

        // GET api/<Categoria>/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/<Categoria>
        [HttpPost]
        public void Post([FromBody] Categoria value)
        {
            _repository.AddOrUpdate(value);
        }


        // DELETE api/<Categoria>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
