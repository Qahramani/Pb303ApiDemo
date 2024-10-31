using Academy.Domain.Entities;
using Academy.Persistence.Contexts;
using Academy.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;

namespace Academy.Persistence.Repositories.Implementation;

public class StudentRepository : EfRepositoryBase<Student, AppDbContext>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }
}
