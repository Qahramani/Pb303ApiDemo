using Core.Persistence.Paging;
using Shop.Application.Dtos.CategoryDtos;
using Shop.Domain.Entities;

namespace Shop.Application.Dtos;

public class ProductGetDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    //public Category? Category { get; set; }
}
public class ProductCreateDto : IDto
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}
public class ProductUpdateDto : IDto
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductListDto : BasePageableDto ,IDto
{
    public List<ProductGetDto> Items { get; set; } = [];
}
