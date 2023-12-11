using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces.IRepositories;

namespace Catalogo.Infra.Repositories
{
    public class Repository<TEntity> : IRepositories<TEntity> where TEntity : Base
    {
        public  Context.CatalogoContext Context ;

        public Repository(Context.CatalogoContext context)
        {
            Context = context;
           
        }

        private DbSet<TEntity> Entity { get { return Context.Set<TEntity>(); } }

        public void Add(TEntity obj)
        {
            obj.DtInclusao = DateTime.Now;
            Entity.Add(obj);
        }

        public void AddAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Add(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Delete(entity);
        }

        public void Delete(TEntity obj)
        {
            Entity.Remove(obj);
        }

        public void Delete(int id)
        {
            Entity.Remove(Get(id));
        }

        public TEntity Get(int id)
        {
            
            return Entity.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        ///  Retorna objetos completos conforme lista parametros com subtabelas maximo de 6 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetFull(int id, string[] parameters)
        {
            IQueryable<TEntity> ret;
            switch (  (parameters !=null ?parameters.Length:0))
            {
                case 0:
                    ret = Entity.AsNoTracking().Where(x => x.Id == id);
                    break;

                case 1:
                    ret = Entity.AsNoTracking().Include(parameters[0]).Where(x => x.Id == id);
                    break;

                case 2:
                    ret = Entity.AsNoTracking()
                                .Include(parameters[0])
                                .Include(parameters[1])
                                .Where(x => x.Id == id);
                    break;

                case 3:
                    ret = Entity.AsNoTracking()
                                .Include(parameters[0])
                                .Include(parameters[1])
                                .Include(parameters[2])
                                .Where(x => x.Id == id);
                    break;

                case 4:
                    ret = Entity.AsNoTracking()
                                .Include(parameters[0])
                                .Include(parameters[1])
                                .Include(parameters[2])
                                .Include(parameters[3])
                                .Where(x => x.Id == id);
                    break;

                case 5:
                    ret = Entity.AsNoTracking()
                                .Include(parameters[0])
                                .Include(parameters[1])
                                .Include(parameters[2])
                                .Include(parameters[3])
                                .Where(x => x.Id == id);
                    break;

                case 6:
                    ret = Entity.AsNoTracking()
                                .Include(parameters[0])
                                .Include(parameters[1])
                                .Include(parameters[2])
                                .Include(parameters[4])
                                .Where(x => x.Id == id);
                    break;


                default:
                    ret = Entity.AsNoTracking().Where(x => x.Id == id);
                    break;
            }

            return ret;

        }

        public TEntity First()
        {
            return Entity.AsNoTracking().FirstOrDefault();
        }

        public IQueryable<TEntity> Get()
        {
            var w = Entity.Where(x => x.Id > 0);

            return w;
        }

        public void Update(TEntity obj)
        {
            obj.DtAlteracao = DateTime.Now;
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void AddOrUpdate(TEntity obj)
        {
            int id = 0;
            int.TryParse(obj.Id.ToString(), out id);
            if (id > 0)
            {
                if (Get(obj.Id).Id > 0)
                {
                    var objUPD = Get(obj.Id);
                    obj.DtInclusao = objUPD.DtInclusao;
                    Update(obj);
                }
                else
                    Add(obj);
            }
            else
            {
                Add(obj);
            }
        }

        public void Commit()
        {
            try
            {
                

                Context.SaveChanges();
                
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public int CommitReturningIdentity(TEntity obj)
        {
            int ret = 0;
            try
            {


                Context.SaveChanges();
                ret = obj.Id;

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return ret;
        }


    }
}