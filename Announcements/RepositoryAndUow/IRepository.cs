using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryAndUow
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Attach(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
