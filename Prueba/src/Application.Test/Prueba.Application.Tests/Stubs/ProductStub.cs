
using Prueba.Aplication.Dto.DTOs;
using Prueba.Domain.Entities;
using System;

namespace Prueba.Application.Unit.Tests.Stubs
{
    static class ProductStub
    {
        public static ProductDTO productDTO = new ProductDTO()
        {
            Id = 1,
            Code = "Producto prueba",
            ExpiryDate = DateTime.Now,
            Name = "Producto de prueba",
            Type = "Prueba"
        };

        public static Product product = new Product()
        {
            Id = 1,
            Code = "Producto prueba",
            ExpiryDate = DateTime.Now,
            Description = "Producto de prueba",
            Type = "Prueba"
        };

    }
}
