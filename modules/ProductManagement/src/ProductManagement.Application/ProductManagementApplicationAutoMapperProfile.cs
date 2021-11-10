﻿using AutoMapper;
using ProductManagement.Categories;
using ProductManagement.Products;

namespace ProductManagement
{
    public class ProductManagementApplicationAutoMapperProfile : Profile
    {
        public ProductManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdateProductDto, ProductDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

        }
    }
}