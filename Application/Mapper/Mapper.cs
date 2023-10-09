using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductsDto>()
                .ForPath(des => des.DefaultVariant.Price, opt => opt.MapFrom(src => src.Price))
                .ForPath(des => des.UrlInfo.Uri, opt => opt.MapFrom(src => src.Url))
                .ReverseMap();
        }

    }
}
