using System;

namespace CodeFirst.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
