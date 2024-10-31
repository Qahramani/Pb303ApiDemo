using Core.Persistence.Repositories;
using Shop.Domain.Entities;
using Shop.Persistence.Contexts;
using Shop.Persistence.Repositories.Contracts;

namespace Shop.Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
