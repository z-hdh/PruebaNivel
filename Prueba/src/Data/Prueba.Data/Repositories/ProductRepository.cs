using System;
using System.Linq;
using CrossCutting.Constants;
using CrossCutting.Exceptions;
using Prueba.Data.Generic;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using CrossCutting.Extension;
using System.Collections.Generic;

namespace Prueba.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public Product AddProduct(Product product)
        {
            if (product.IsNull())
            {
                throw new ArgumentNullException();
            }

            Create(product);
            SaveChanges();

            return Get(x => x.Id == product.Id).ToList().FirstOrDefault();
        }

        public Product DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNotValidException(Exceptions.Code.INVALID_OBJECT, Exceptions.Message.INVALID_OBJECT);
            }

            var ent = Get(x => x.Id == id).ToList().FirstOrDefault();

            if(!ent.IsNull())
            {
                Delete(ent);

                SaveChanges();
            }

            return ent;
        }

        public List<Product> GetExpiredProducts()
        {
            return Get(x => x.ExpiryDate < DateTime.Now).ToList();
        }
    }
}
