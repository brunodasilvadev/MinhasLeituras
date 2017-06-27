using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BS.MinhasLeituras.Domain.Interfaces.Repository;
using BS.MinhasLeituras.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;

namespace BS.MinhasLeituras.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MinhasLeiturasContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(MinhasLeiturasContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            return objReturn;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
