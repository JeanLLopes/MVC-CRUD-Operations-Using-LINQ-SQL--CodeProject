using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace MVC_CRUD.Web.Data
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal MVCEntities Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(MVCEntities context)
        {
           Context = context;
           DbSet = context.Set<TEntity>();
        }


        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }


        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityDataDelete)
        {
            if (Context.Entry(entityDataDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityDataDelete);
            }

            DbSet.Remove(entityDataDelete);
        }


        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}