﻿using AutoMapper;

namespace VShop.ProductApi;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Category, CategoryDTO>().ReverseMap();
    CreateMap<Product, ProductDTO>();

    CreateMap<Product, ProductDTO>()
    .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
  }
}
