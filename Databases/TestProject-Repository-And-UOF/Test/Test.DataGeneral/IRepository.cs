using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.DataGeneral
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> All();

        IEnumerable<T> All(Expression<Func<T, bool>> filteExpression);

        IEnumerable<T1> All<T1>(Expression<Func<T, T1>> selectExpression);

        IEnumerable<T1> All<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> selectExpression);

        void Add(T entity);

        void Delete(T entity);
    }
}
