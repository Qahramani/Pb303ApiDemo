using Academy.Application.Dtos;
using Academy.Domain.Entities;
using AutoMapper;
using Core.Persistence.Paging;

namespace Academy.Application.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<StudentDto,Student>().ReverseMap();
        CreateMap<StudentCreatetDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto,Student>().ReverseMap();
        CreateMap<StudentListDto,Paginate<Student>>().ReverseMap();
    }
}
