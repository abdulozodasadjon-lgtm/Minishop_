using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepo(AppDbContext context) : IProductRepo
{

    private readonly AppDbContext _context = context;

    public async Task<bool> AddProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var prod = await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        if(prod != null)
        {
            _context.Products.Remove(prod);
        }

        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var prod = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        return prod??new();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var prod = await _context.Products.FirstOrDefaultAsync(x=>x.Id==product.Id);
        if(prod != null)
        {
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.CategoryId = product.CategoryId;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
