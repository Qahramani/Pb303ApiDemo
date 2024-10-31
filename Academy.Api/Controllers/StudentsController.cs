using Academy.Application.Dtos;
using Academy.Application.Services.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentManager;

    public StudentsController(IStudentService studentService)
    {
        _studentManager = studentService;
    }

    [HttpGet("{id?}")]
    public async Task<IActionResult> GetById(int? id)
    {
        if (id == null) return NotFound();

        var student = await _studentManager.GetAsync(id.Value);

        if(student == null) return NotFound();

        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> GetByPage([FromQuery]PageRequest pageRequest)
    {
        var list = await _studentManager.GetListAsync(index : pageRequest.Index, size : pageRequest.Size);
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentCreatetDto createDto)
    {
        var list = await _studentManager.AddAsync(createDto);

        return Ok(list);
    }
}
