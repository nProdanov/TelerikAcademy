using System;

namespace Test.DataGeneral
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
