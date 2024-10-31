using Academy.Application.Dtos;
using Academy.Domain.Entities;
using Academy.Persistence.Repositories.Abstraction;
using AutoMapper;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Academy.Application.Services.StudentService;

public class StudentManager : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentManager(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentDto?> GetAsync(int id)
    {
        var entity = await _studentRepository.GetAsync(id);

        if (entity == null) throw new Exception("Not found");

        var dto = _mapper.Map<StudentDto>(entity);

        return dto;
    }

    public async Task<StudentDto?> GetAsync(Expression<Func<Student, bool>> predcate, Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null)
    {
        var entity = await _studentRepository.GetAsync(predcate, include);

        if (entity == null) throw new Exception("Not found");

        var dto = _mapper.Map<StudentDto>(entity);

        return dto;
    }

    public async Task<StudentListDto> GetListAsync(Expression<Func<Student, bool>>? predcate = null, Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null, Func<IQueryable<Student>, IOrderedQueryable<Student>>? orderBy = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var list = await _studentRepository.GetListAsync(predcate, include, orderBy, index, size, enableTracking);

        if (list == null) throw new Exception("Not found");

        var dtoList = _mapper.Map<StudentListDto>(list);

        return dtoList;
    }

    public async Task<StudentDto> AddAsync(StudentCreatetDto createtDto)
    {
        var entity = _mapper.Map<Student>(createtDto);

        if (entity == null) throw new Exception("Not found");

        var createdEntity = await _studentRepository.AddAsync(entity);

        var createdDto = _mapper.Map<StudentDto>(createdEntity);

        return createdDto;
    }

    public async Task<StudentDto> UpdateAsync(int id,StudentUpdateDto updateDto)
    {
        var existEntity = await _studentRepository.GetAsync(id);

        if (existEntity == null) throw new Exception("Not found");

        existEntity = _mapper.Map(updateDto, existEntity);

        var updatedEntity = await _studentRepository.UpdateAsync(existEntity);

        var updatedDto = _mapper.Map<StudentDto>(updatedEntity);

        return updatedDto;
    }

    public async Task<StudentDto> DeleteAsync(int id)
    {
        var entity = await _studentRepository.GetAsync(id);

        if (entity == null) throw new Exception("Not found");

        var deletedEntity = await _studentRepository.DeleteAsync(entity);

        var deletedDto = _mapper.Map<StudentDto>(deletedEntity);

        return deletedDto;
    }
}