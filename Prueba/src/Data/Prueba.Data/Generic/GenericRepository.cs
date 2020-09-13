using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Prueba.Domain.Generic;

namespace Prueba.Data.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(T entity)
        {
            try
            {
                _unitOfWork.Context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _unitOfWork.Context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                var listProp = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var prop in listProp)
                {
                    query = query.Include(prop);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public PruebaDbContext GetContext()
        {
            return _unitOfWork.Context;
        }

        public void SaveChanges()
        {
            _unitOfWork.Comit();
        }
    }
}
