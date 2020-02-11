using AutoMapper;
using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.UI.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.UI.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketEntity, BasketVM>().ReverseMap();
        }
    }
}
