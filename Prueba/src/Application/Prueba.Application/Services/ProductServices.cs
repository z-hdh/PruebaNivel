using System;
using System.Linq;
using CrossCutting.Constants;
using CrossCutting.Exceptions;
using Prueba.Aplication.Dto.DTOs;
using Prueba.Application.Helpers;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Mapping.AutoMapper;
using Prueba.Services.RabbitMQ;
using CrossCutting.Extension;
using System.Collections.Generic;

namespace Prueba.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductHelper _productHelper;
        private readonly AmqpService _amqpService;

        public ProductServices (IProductRepository productRepository, IProductHelper productHelper, AmqpService amqpService)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(amqpService));
            _productHelper = productHelper ?? throw new ArgumentNullException(nameof(amqpService));
            _amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        public ProductDTO AddProduct(ProductDTO product)
        {
            if (!_productHelper.ValidateProduct(product))
            {
                throw new InvalidObjectException(Exceptions.Code.INVALID_OBJECT, Exceptions.Message.INVALID_OBJECT);
            }

            var ent = MappingManagement.GetMappingConfiguration().Map<Product>(product);

            ent = _productRepository.AddProduct(ent);

            return MappingManagement.GetMappingConfiguration().Map<ProductDTO>(ent);
        }

        public ProductDTO DeleteProductById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNotValidException(Exceptions.Code.INVALID_OBJECT, Exceptions.Message.INVALID_OBJECT);
            }

            var ent = _productRepository.DeleteProduct(id);

            var response = MappingManagement.GetMappingConfiguration().Map<ProductDTO>(ent);

            _amqpService.PublishMessage(QueueLists.REMOVE_ITEM, response);

            return response;
        }

        public List<ProductDTO> GetProducts()
        {
            var ent = _productRepository.Get().ToList();

            return MappingManagement.GetMappingConfiguration().Map<List<ProductDTO>>(ent);
        }

        public ProductDTO GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNotValidException(Exceptions.Code.INVALID_OBJECT, Exceptions.Message.INVALID_OBJECT);
            }

            var ent = _productRepository.Get(x => x.Id == id).ToList().FirstOrDefault();

            return MappingManagement.GetMappingConfiguration().Map<ProductDTO>(ent);
        }

        public ProductDTO GetProductByName(string name)
        {
            if (name.IsNull())
            {
                throw new ArgumentNullException(nameof(name));
            }

            var ent = _productRepository.Get(x => x.Description == name).ToList().FirstOrDefault();

            if (ent.IsNull())
            {
                throw new ArgumentNullException();
            }

            return MappingManagement.GetMappingConfiguration().Map<ProductDTO>(ent);
        }

        public void NotifyExpiredProducts()
        {
            var ListEnt = _productRepository.GetExpiredProducts();
            
            if (!ListEnt.IsNull())
            {
                var response = MappingManagement.GetMappingConfiguration().Map<List<ProductDTO>>(ListEnt);

                _amqpService.PublishMessage(QueueLists.EXPIRED_ITEMS, response);
            } 
        }
    }
}
