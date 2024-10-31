using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Dtos;
using Shop.Application.Dtos.CategoryDtos;
using Shop.Application.Services.Contracts;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productManager;

    public ProductController(IProductService productManager)
    {
        _productManager = productManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetByPage([FromQuery] PageRequest pageRequest)
    {
        var productList = await _productManager.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

        return Ok(productList);
    }

    [HttpGet("{id?}")]
    public async Task<IActionResult> Get(int? id)
    {
        if (id == null) return NotFound();

        var product = await _productManager.GetAsync(id.Value);

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCreateDto createDto)
    {
        var createdProduct = await _productManager.AddAsync(createDto);

        return Ok(createdProduct);
    }

    [HttpPut("{id?}")]
    public async Task<IActionResult> Put(int? id, [FromBody] ProductUpdateDto updateDto)
    {
        if (id == null) return NotFound();

        var updatedProduct = await _productManager.UpdateAsync(id.Value, updateDto);

        return Ok(updatedProduct);
    }

    [HttpDelete("{id?}")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var deletedProduct = await _productManager.DeleteAsync(id.Value);

        return Ok(deletedProduct);
    }
}
