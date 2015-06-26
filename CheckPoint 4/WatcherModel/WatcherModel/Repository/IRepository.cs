using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WatcherModel.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
        void SaveChanges();
    }
}
