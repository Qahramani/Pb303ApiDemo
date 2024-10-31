using Core.Persistence.Repositories;

namespace Shop.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

}