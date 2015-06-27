using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WatcherModel.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext Context;

        public Repository(DbContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }
            Context = dataContext;
        }

        public virtual void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
