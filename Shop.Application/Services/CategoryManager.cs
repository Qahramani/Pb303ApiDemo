using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Shop.Application.Dtos;
using Shop.Application.Dtos.CategoryDtos;
using Shop.Application.Services.Contracts;
using Shop.Domain.Entities;
using Shop.Persistence.Repositories;
using Shop.Persistence.Repositories.Contracts;
using System.Linq.Expressions;

namespace Shop.Application.Services;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryGetDto?> GetAsync(int id)
    {
        var entity = await _categoryRepository.GetAsync(id);

        if (entity == null) throw new Exception("Category not found");

        var dto = _mapper.Map<CategoryGetDto>(entity);

        return dto;
    }

    public async Task<CategoryGetDto?> GetAsync(Expression<Func<Category, bool>> predcate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        var entity = await _categoryRepository.GetAsync(predcate, include);

        if (entity == null) throw new Exception("Category not found");

        var dto = _mapper.Map<CategoryGetDto>(entity);

        return dto;
    }

    public async Task<CategoryListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var list = await _categoryRepository.GetListAsync(predicate, include, orderBy, index, size, enableTracking);

        if (list == null) throw new Exception("Not found");

        var dtoList = _mapper.Map<CategoryListDto>(list);

        return dtoList;
    }

    public async Task<CategoryGetDto> AddAsync(CategoryCreateDto createtDto)
    {
        var entity = _mapper.Map<Category>(createtDto);

        var createdEntity = await _categoryRepository.AddAsync(entity);

        var createdDto = _mapper.Map<CategoryGetDto>(createdEntity);

        return createdDto;
    }

    public async Task<CategoryGetDto> UpdateAsync(int id, CategoryUpdateDto updateDto)
    {
        var existEntity =await _categoryRepository.GetAsync(id);

        if (existEntity == null) throw new Exception("Category not found");

        existEntity = _mapper.Map(updateDto, existEntity);

        var updatedEntity = await _categoryRepository.UpdateAsync(existEntity);

        var updatedDto = _mapper.Map<CategoryGetDto>(updatedEntity);

        return updatedDto;
    }
    public async Task<CategoryGetDto> DeleteAsync(int id)
    {
        var entity = await _categoryRepository.GetAsync(id);

        if (entity == null) throw new Exception("Category not found");

        var deletedEntity = await _categoryRepository.DeleteAsync(entity);

        var deletedDto = _mapper.Map<CategoryGetDto>(deletedEntity);

        return deletedDto;
    }
}
