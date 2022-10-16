using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Models;

namespace DeLaSalle.Ecommerce.Api.Repositories
{
    public class InMemoryProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> _products;

        public InMemoryProductCategoryRepository()
        {
            _products = new List<ProductCategory>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = _products.Any(p => p.Id == id && p.IsDeleted == false);
            if (exists)
            {
                _products.RemoveAll(p => p.Id == id);
                return true;
            }
            

            return false;
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return _products;
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id && p.IsDeleted ==false);
            return product;
        }

        public async Task<ProductCategory> SaveAsync(ProductCategory productCategory)
        {
            productCategory.Id = _products.Count + 1;
            _products.Add(productCategory);
            return productCategory;
        }

        public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory)
        {
            var index = _products.FindIndex(x => x.Id == productCategory.Id);
            if (index != -1)
            {
                _products[index] = productCategory;
            }
            return productCategory;
        }
    }
}
