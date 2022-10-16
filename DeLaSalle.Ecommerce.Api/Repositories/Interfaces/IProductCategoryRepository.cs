using DeLaSalle.Ecommerce.Core.Models;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetByIdAsync(int id);
        Task<ProductCategory> SaveAsync(ProductCategory productCategory);
        Task<ProductCategory> UpdateAsync(ProductCategory productCategory);
        Task<bool> DeleteAsync(int id);
    }
}
