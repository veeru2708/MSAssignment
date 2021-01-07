using Contacts.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contacts.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
      
        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
            
        }

        public IQueryable<T> FindAll()
        {
            var test = this.RepositoryContext.Set<T>().Local.AsQueryable();
            return this.RepositoryContext.Set<T>().Local.AsQueryable();
                
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var test = this.RepositoryContext.Set<T>().Local;

            return this.RepositoryContext.Set<T>().Local.AsQueryable()
                .Where(expression)
                .AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
