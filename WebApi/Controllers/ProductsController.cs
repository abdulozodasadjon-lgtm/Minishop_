using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await service.GetProductsAsync();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await service.GetProductAsync(id);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAndUpdateProductDto dto)
    {
        var response = await service.AddProductAsync(dto);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CreateAndUpdateProductDto dto)
    {
        var response = await service.UpdateProductAsync(id, dto);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteProductAsync(id);
        return StatusCode((int)response.StatusCode, response);
    }
}
