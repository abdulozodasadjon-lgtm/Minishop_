using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategoryAsync(Category category);
    Task<ApiResponse<bool>> DeleteCategoryAsync (int id);
    Task<ApiResponse<bool>> UpdateCategoryAsync (Category category);
    Task<ApiResponse<List<Category>>> GetCategorysAsync ();
    Task<ApiResponse<Category>> GetCategoryAsync (int id);
}
