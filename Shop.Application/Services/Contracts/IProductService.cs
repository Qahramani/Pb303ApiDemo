using Microsoft.EntityFrameworkCore.Query;
using Shop.Application.Dtos;
using Shop.Domain.Entities;
using System.Linq.Expressions;

namespace Shop.Application.Services.Contracts;

public interface IProductService
{
    Task<ProductGetDto?> GetAsync(int id);

    Task<ProductGetDto?> GetAsync(Expression<Func<Product, bool>> predcate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null);

    Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null,
                                   Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
                                   Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
                                   int index = 0, int size = 10, bool enableTracking = true);
    Task<ProductGetDto> AddAsync(ProductCreateDto createtDto);
    Task<ProductGetDto> UpdateAsync(int id, ProductUpdateDto updateDto);
    Task<ProductGetDto> DeleteAsync(int id);
}
