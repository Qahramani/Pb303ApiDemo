using AutoMapper;
using Core.Persistence.Paging;
using Shop.Application.Dtos;
using Shop.Application.Dtos.CategoryDtos;
using Shop.Domain.Entities;

namespace Shop.Application.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        CreateMap<Paginate<Category>, CategoryListDto>().ReverseMap();


        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Paginate<Product>, ProductListDto>().ReverseMap();
    }
}
