using Academy.Domain.Enums;
using Core.Persistence.Repositories;
using System.Globalization;

namespace Academy.Domain.Entities;

public class Student : BaseEntity
{
    public required string  Name{ get; set; }
    public int Age { get; set; }
    public StudentStatusType StatusType{ get; set; }
}
