using Core.Persistence.Repositories;
using Shop.Domain.Entities;
using Shop.Persistence.Contexts;
using Shop.Persistence.Repositories.Contracts;

namespace Shop.Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
