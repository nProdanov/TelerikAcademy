using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using Test.Data;

namespace Test.DataGeneral
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
            IQueryable<T> result = this.dbSet;

            return result.Where(filterExpression).ToList();
        }

        public IEnumerable<T1> All<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> selectExpression)
        {
            IQueryable<T> filteredQuery = this.dbSet.Where(filterExpression);
            IQueryable<T1> result = filteredQuery.Select(selectExpression);

            return result.ToList();
        }

        public IEnumerable<T1> All<T1>(Expression<Func<T, T1>> selectExpression)
        {
            IQueryable<T1> result = this.dbSet.Select(selectExpression);

            return result.ToList();
        }

        public void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
