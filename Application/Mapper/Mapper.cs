using System.Collections.Generic;
using System.Linq;
using Application.Dtos;
using AutoMapper;
using Domain.Enums;
using Domain.Models;

namespace Application.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetProductsDto,Product>()
                .ForPath(des => des.Price, opt =>
                   opt.MapFrom(src => src.DefaultVariant.FirstOrDefault() != null ? src.DefaultVariant.FirstOrDefault().Price.SellingPrice : 0))
               .ForPath(des => des.Url, opt => opt.MapFrom(src => src.UrlInfo.Uri))
               .ForPath(des => des.Status, opt  =>
               opt.MapFrom(src => src.Status== "marketable" ? 1 : 0))
                .ReverseMap();


        }

    }
}
