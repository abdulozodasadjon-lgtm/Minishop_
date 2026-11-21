using System.Net;
using Application.Dtos;
using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services;

public class ProductService(IProductRepo repo) : IProductService
{
    private readonly IProductRepo _repo = repo;

    public async Task<ApiResponse<bool>> AddProductAsync(CreateAndUpdateProductDto productdto)
    {
        var product = new Product
        {
            Name = productdto.Name,
            Price = productdto.Price,
            CategoryId = productdto.CategoryId
        };

        var result = await _repo.AddProduct(product);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Added.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
    {
        var existing = await _repo.GetProductAsync(id);
        if (existing.Id == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Product not found.", false);
        }

        var result = await _repo.DeleteProduct(id);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", false);
    }

    public async Task<ApiResponse<Product>> GetProductAsync(int id)
    {
        var product = await _repo.GetProductAsync(id);
        return product.Id == 0
            ? new ApiResponse<Product>(HttpStatusCode.NotFound, "Product not found.", null)
            : new ApiResponse<Product>(HttpStatusCode.OK, "Success.", product);
    }

    public async Task<ApiResponse<List<Product>>> GetProductsAsync()
    {
        var products = await _repo.GetProductsAsync();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "Success.", products);
    }

    public async Task<ApiResponse<bool>> UpdateProductAsync(int id, CreateAndUpdateProductDto productdto)
    {
        var existing = await _repo.GetProductAsync(id);
        if (existing.Id == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Product not found.", false);
        }

        existing.Name = productdto.Name;
        existing.Price = productdto.Price;
        existing.CategoryId = productdto.CategoryId;

        var updated = await _repo.UpdateProduct(existing);
        return updated
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", false);
    }
}
