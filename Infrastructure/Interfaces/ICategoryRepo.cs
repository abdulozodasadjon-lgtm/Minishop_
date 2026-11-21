using Domain.Models;

namespace Infrastructure.Interfaces;

public interface ICategoryRepo
{
    Task<bool> AddCategory(Category category);
    Task<List<Category>> GetCategorysAsync();
    Task<Category> GetCategoryAsync(int id);
    Task<bool> DeleteCategory(int id);
    Task<bool> UpdateCategory(Category category);
}
