using Dapper;
using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Models;

namespace DeLaSalle.Ecommerce.Api.Repositories
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly IApplicationDbContext context;

        public ProductCategoryRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product == null)
                return false;

            product.IsDeleted = true;
            return await context.Connection.UpdateAsync(product);

        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            const string sql = "SELECT * FROM ProductCategory WHERE isDeleted = 0";
            var categories = await context.Connection.QueryAsync<ProductCategory>(sql);
            return categories.ToList();
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            var product = await context.Connection.GetAsync<ProductCategory>(id);
            if (product == null)
                return null;


            return product.IsDeleted==true?null:product;
        }

        public async Task<ProductCategory> SaveAsync(ProductCategory productCategory)
        {
            var id = await context.Connection.InsertAsync(productCategory);
            productCategory.Id = id;
            return productCategory;
        }

        public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory)
        {
            await context.Connection.UpdateAsync(productCategory);
            return productCategory;
        }
    }
}
