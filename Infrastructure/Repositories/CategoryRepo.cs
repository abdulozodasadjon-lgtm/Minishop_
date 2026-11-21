using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepo(AppDbContext context) : ICategoryRepo
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AddCategory(Category Category)
    {
        await _context.Categories.AddAsync(Category);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var prod = await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
        if(prod != null)
        {
            _context.Categories.Remove(prod);
        }

        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        var prod = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        return prod??new();
    }

    public async Task<List<Category>> GetCategorysAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        var prod = await _context.Categories.FirstOrDefaultAsync(x=>x.Id==category.Id);
        if(prod != null)
        {
            prod.Name = category.Name;
        }

        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
