using Application.Dtos;
using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductAsync(CreateAndUpdateProductDto productdto);
    Task<ApiResponse<bool>> DeleteProductAsync (int id);
    Task<ApiResponse<bool>> UpdateProductAsync (int id, CreateAndUpdateProductDto productdto);
    Task<ApiResponse<List<Product>>> GetProductsAsync ();
    Task<ApiResponse<Product>> GetProductAsync (int id);
}
