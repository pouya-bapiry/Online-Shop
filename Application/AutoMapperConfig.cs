using AutoMapper;
using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.PriceWithComma, opt => opt.MapFrom(src => src.Price.ToString("###,###")))
            .ReverseMap();
        }

    }
}
