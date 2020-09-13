using Prueba.Aplication.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Application.Helpers
{
    public interface IProductHelper
    {
        bool ValidateProduct(ProductDTO product);
    }
}
