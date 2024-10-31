using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using Shop.Application.Dtos;
using Shop.Application.Services.Contracts;
using Shop.Domain.Entities;
using Shop.Persistence.Repositories.Contracts;
using System;
using System.Linq.Expressions;

namespace Shop.Application.Services;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public ProductManager(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryService = categoryService;
    }




    public async Task<ProductGetDto?> GetAsync(int id)
    {
        var entity = await _productRepository.GetAsync(id);

        if (entity == null) throw new Exception("Product not found");

        var dto = _mapper.Map<ProductGetDto>(entity);

        return dto;
    }

    public async Task<ProductGetDto?> GetAsync(Expression<Func<Product, bool>> predcate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        var entity = await _productRepository.GetAsync(predcate, include);

        if (entity == null) throw new Exception("Product not found");

        var dto = _mapper.Map<ProductGetDto>(entity);

        return dto;
    }

    public async  Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var list = await _productRepository.GetListAsync(predicate, include, orderBy, index, size, enableTracking);

        if (list == null) throw new Exception("Not found");

        var dtoList = _mapper.Map<ProductListDto>(list);

        return dtoList;
    }

    public async Task<ProductGetDto> AddAsync(ProductCreateDto createtDto)
    {
        await _categoryService.GetAsync(createtDto.CategoryId);

        var entity = _mapper.Map<Product>(createtDto);

        var createdEntity = await _productRepository.AddAsync(entity);

        var createdDto = _mapper.Map<ProductGetDto>(createdEntity);

        return createdDto;
    }
    public async Task<ProductGetDto> UpdateAsync(int id, ProductUpdateDto updateDto)
    {
        var existEntity = await _productRepository.GetAsync(id);

        if (existEntity == null) throw new Exception("Product not found");

        await _categoryService.GetAsync(updateDto.CategoryId);

        existEntity = _mapper.Map(updateDto, existEntity);

        var updatedEntity = await _productRepository.UpdateAsync(existEntity);

        var updatedDto = _mapper.Map<ProductGetDto>(updatedEntity);

        return updatedDto;
    }


    public async Task<ProductGetDto> DeleteAsync(int id)
    {
        var entity = await _productRepository.GetAsync(id);

        if (entity == null) throw new Exception("Product not found");

        var deletedEntity = await _productRepository.DeleteAsync(entity);

        var deletedDto = _mapper.Map<ProductGetDto>(deletedEntity);

        return deletedDto;
    }
}
