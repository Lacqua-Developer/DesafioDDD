using System.Collections.Generic;
using System.Linq;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Entities.Modules.Produtos;

namespace Catalogo.Domain.Interfaces.IRepositories
{
    public interface IRepositories<TEntity> 
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> obj);
        void DeleteAll(IEnumerable<TEntity> obj);
        void Delete(TEntity obj);
        void Delete(int id);

        IQueryable<TEntity> GetFull(int id, string[] parameters);
        TEntity Get(int id);

        TEntity First();
        IQueryable<TEntity> Get();
        void Update(TEntity obj);

        void Commit();

        void AddOrUpdate(TEntity obj);

        int CommitReturningIdentity(TEntity obj);

    }
}
