using Microsoft.EntityFrameworkCore.Query;
using Shop.Application.Dtos.CategoryDtos;
using Shop.Domain.Entities;
using System.Linq.Expressions;

namespace Shop.Application.Services.Contracts;

public interface ICategoryService
{
    Task<CategoryGetDto?> GetAsync(int id);

    Task<CategoryGetDto?> GetAsync(Expression<Func<Category, bool>> predcate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

    Task<CategoryListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null,
                                   Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
                                   Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
                                   int index = 0, int size = 10, bool enableTracking = true);
    Task<CategoryGetDto> AddAsync(CategoryCreateDto createtDto);
    Task<CategoryGetDto> UpdateAsync(int id, CategoryUpdateDto updateDto);
    Task<CategoryGetDto> DeleteAsync(int id);
}
