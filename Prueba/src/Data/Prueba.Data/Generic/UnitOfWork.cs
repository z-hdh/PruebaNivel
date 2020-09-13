
namespace Prueba.Data.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        public PruebaDbContext Context { get; }

        public UnitOfWork (PruebaDbContext context)
        {
            Context = context;
        }

        public void Comit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public PruebaDbContext GetContext()
        {
            return Context;
        }
    }
}
