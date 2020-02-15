using AutoMapper;
using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.UI.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.UI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductVM>();
            CreateMap<EditProductVM, ProductEntity>()
                .ForMember(x => x.AddDate, opt => opt.UseDestinationValue())
                .ReverseMap();
            CreateMap<AddProductVM, ProductEntity>()
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(x => x.AddDate, opt => opt.MapFrom(src => DateTime.Now));   
        }
    }
}
