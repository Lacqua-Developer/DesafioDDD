using Catalogo.Domain.Entities.Modules.Produtos;
using Catalogo.Domain.Interfaces.IRepositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.UseCases
{
    public class CategoriaUseCase : IRepositories<Categoria>
    {

        private readonly IRepositories<Categoria> _repository;


        public CategoriaUseCase(IRepositories<Categoria> repository)
        {
            _repository = repository;
        }

        public void Add(Categoria obj)
        {
            _repository.Add(obj);
        }

        public void AddAll(IEnumerable<Categoria> obj)
        {
            _repository.AddAll(obj);
        }

        public void AddOrUpdate(Categoria obj)
        {
            _repository.AddOrUpdate(obj);
        }

        public void Commit()
        {
            _repository.Commit();
        }

        public int CommitReturningIdentity(Categoria obj)
        {
            return _repository.CommitReturningIdentity(obj);
        }

        public void Delete(Categoria obj)
        {
            _repository.Delete(obj);    
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteAll(IEnumerable<Categoria> obj)
        {
            _repository.DeleteAll(obj);
        }

        public Categoria First()
        {
            return (Categoria) _repository.First(); 
        }

        public Categoria Get(int id)
        {
            return (_repository.Get(id));
        }

        public IQueryable<Categoria> Get()
        {
            return _repository.Get();
        }

        public IQueryable<Categoria> GetFull(int id, string[] parameters)
        {
            return  _repository.GetFull(id, parameters);
        }

        public void Update(Categoria obj)
        {
            _repository.Update(obj);
        }
    }
}
