using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WatcherModel.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext context;

        public Repository(ModelContainer dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("context");
            }
            context = dataContext;
        }

        public virtual void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
