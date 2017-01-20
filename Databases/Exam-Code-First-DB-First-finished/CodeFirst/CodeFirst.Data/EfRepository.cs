using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CodeFirst.Data
{
    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public EfRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public IEnumerable<T> All()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> filterExpression)
        {
            return this.dbSet.Where(filterExpression).ToList();
        }

        public IEnumerable<T1> All<T1>(Expression<Func<T, T1>> selectExpression)
        {
            return this.dbSet.Select(selectExpression).ToList();
        }

        public IEnumerable<T1> All<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> selectExpression)
        {
            return this.dbSet
                    .Where(filterExpression)
                    .Select(selectExpression)
                    .ToList();
        }

        public void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
