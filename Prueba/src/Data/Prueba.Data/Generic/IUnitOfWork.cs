using System;

namespace Prueba.Data.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        PruebaDbContext Context { get; }

        void Comit();

        PruebaDbContext GetContext();
    }
}
