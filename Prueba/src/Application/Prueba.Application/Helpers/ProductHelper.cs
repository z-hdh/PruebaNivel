using System;
using System.Collections.Generic;
using System.Text;
using Prueba.Aplication.Dto.DTOs;

namespace Prueba.Application.Helpers
{
    public class ProductHelper : IProductHelper
    {
        public bool ValidateProduct(ProductDTO product)
        {
            bool IsValid = true;

            if (product == null)
            {
                IsValid = false;
            }

            // TODO : Implementar las validaciones necesarias.

            return IsValid;
        }
    }
}
