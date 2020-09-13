using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prueba.Domain.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get();

        IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        void Create(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
