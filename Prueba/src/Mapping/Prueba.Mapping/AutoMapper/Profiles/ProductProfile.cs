using AutoMapper;
using Prueba.Aplication.Dto.DTOs;
using Prueba.Domain.Entities;

namespace Prueba.Mapping.AutoMapper.Profiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dto => dto.Name, e => e.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}
