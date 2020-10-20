using AutoMapper;
using CoreApp.Entities;
using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductViewModel>();
            CreateMap<Stocks, ProductViewModel>();
        }
    }
}
