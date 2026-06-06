using Application.CQRS.ProductCommandQuery.Query;
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

            CreateMap<Product, GetProductQueryResponse>()
              .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ProductName.ToUpper()))
              .ForMember(dest => dest.PriceWithComma, opt => opt.MapFrom(src => String.Format("{0:n0}", src.Price)));

        }

    }
}
