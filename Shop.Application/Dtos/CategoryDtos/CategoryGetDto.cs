using Core.Persistence.Paging;
using Shop.Domain.Entities;

namespace Shop.Application.Dtos.CategoryDtos;

public class CategoryGetDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Product> MyProperty { get; set; } = [];
}
public class CategoryCreateDto : IDto
{
    public required string Name { get; set; }
}
public class CategoryUpdateDto : IDto
{
    public required string Name { get; set; }
}

public class CategoryListDto : BasePageableDto, IDto
{
    public List<CategoryGetDto> Items { get; set; } = [];
}


