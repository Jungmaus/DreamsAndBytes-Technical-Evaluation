using AutoMapper;
using DreamsAndBytes.API.Models.Product;
using DreamsAndBytes.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            CreateMap<ProductEntity, ProductAddRequestModel>().ReverseMap();
        }
    }
}
