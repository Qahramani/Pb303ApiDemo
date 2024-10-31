using Core.Persistence.Repositories;
using Shop.Domain.Entities;

namespace Shop.Persistence.Repositories.Contracts;

public interface ICategoryRepository : IRepositoryAsync<Category>
{
}
