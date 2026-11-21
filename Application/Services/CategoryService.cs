using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services;

public class CategoryService(ICategoryRepo repo) : ICategoryService
{
    private readonly ICategoryRepo _repo = repo;

    public async Task<ApiResponse<bool>> AddCategoryAsync(Category category)
    {
        var result = await _repo.AddCategory(category);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Added.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        var existing = await _repo.GetCategoryAsync(id);
        if (existing.Id == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Category not found.", false);
        }

        var result = await _repo.DeleteCategory(id);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", false);
    }

    public async Task<ApiResponse<Category>> GetCategoryAsync(int id)
    {
        var category = await _repo.GetCategoryAsync(id);
        return category.Id == 0
            ? new ApiResponse<Category>(HttpStatusCode.NotFound, "Category not found.", null)
            : new ApiResponse<Category>(HttpStatusCode.OK, "Success.", category);
    }

    public async Task<ApiResponse<List<Category>>> GetCategorysAsync()
    {
        var categories = await _repo.GetCategorysAsync();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK, "Success.", categories);
    }

    public async Task<ApiResponse<bool>> UpdateCategoryAsync(Category category)
    {
        var existing = await _repo.GetCategoryAsync(category.Id);
        if (existing.Id == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Category not found.", false);
        }

        existing.Name = category.Name;
        var updated = await _repo.UpdateCategory(existing);
        return updated
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", false);
    }
}
