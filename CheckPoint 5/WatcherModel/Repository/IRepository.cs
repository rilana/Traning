using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WatcherModel.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
    }
}
