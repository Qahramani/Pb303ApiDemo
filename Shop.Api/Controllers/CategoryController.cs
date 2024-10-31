using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Dtos;
using Shop.Application.Dtos.CategoryDtos;
using Shop.Application.Services.Contracts;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "SuperAdmin")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByPage([FromQuery] PageRequest pageRequest)
    {
        var categoryList = await _categoryService.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

        return Ok(categoryList);
    }

    [HttpGet("{id?}")]
    public async Task<IActionResult> Get(int? id)
    {
        if (id == null) return NotFound();

        var category = await _categoryService.GetAsync(id.Value);

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryCreateDto createDto)
    {
        var createdCategory = await _categoryService.AddAsync(createDto);

        return Ok(createdCategory);
    }

    [HttpPut("{id?}")]
    public async Task<IActionResult> Put(int? id, [FromBody] CategoryUpdateDto updateDto)
    {
        if (id == null) return NotFound();

        var updatedCategory = await _categoryService.UpdateAsync(id.Value, updateDto);

        return Ok(updatedCategory);
    }
    [HttpDelete("{id?}")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var deletedCategory = await _categoryService.DeleteAsync(id.Value);

        return Ok(deletedCategory);
    }
}
