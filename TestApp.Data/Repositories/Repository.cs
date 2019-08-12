using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestApp.BusinessLogic.Infrastructure.Interfaces;

namespace TestApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ApplicationDbContext _dbCtx;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbCtx)
        {
            _dbCtx = dbCtx;
            this.dbSet = _dbCtx.Set<T>();
        }

        public T Add(T newEntity)
        {
            T savedEntity = this.dbSet.Add(newEntity);
            _dbCtx.SaveChanges();
            return savedEntity;
        }

        public T FindFirst(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate).FirstOrDefault();
        }

        public async Task<T> Get(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate = null)
        {
            return this.dbSet;
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
            _dbCtx.SaveChanges();
        }
    }
}
