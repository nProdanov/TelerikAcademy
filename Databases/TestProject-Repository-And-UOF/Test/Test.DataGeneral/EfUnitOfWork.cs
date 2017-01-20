using System;
using System.Data.Entity;

namespace Test.DataGeneral
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DbContext context;

        public EfUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
