using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IProductRepo
{
    Task<bool> AddProduct(Product product);
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<bool> DeleteProduct(int id);
    Task<bool> UpdateProduct(Product product);
    
}
