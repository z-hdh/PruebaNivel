using CrossCutting.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Aplication.Dto.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public DateTime ExpiryDate { get; set; }

        public override string ToString()
        {
            return Id + "|" + Code + "|" + (!string.IsNullOrEmpty(Name) ? Name : Literal.SIN_DESCRIPCION);
        }
    }
}
