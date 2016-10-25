using EFModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryAndUow
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> dbSet;

        private Context context;

        protected Context DbContext
        {
            get { return context ?? (context = ContextProvider.GetContext()); }

        }

        protected IContextProvider ContextProvider { get; private set; }

        public GenericRepository(IContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
            dbSet = DbContext.Set<T>();
        }        

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Attach(T entity)
        {
            context.Entry(entity).State = EntityState.Unchanged;
            dbSet.Attach(entity);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }
        
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            try
            {
                return dbSet.Where(where).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
