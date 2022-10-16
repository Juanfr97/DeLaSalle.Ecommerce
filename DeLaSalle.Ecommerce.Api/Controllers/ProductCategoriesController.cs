using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoriesController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<ProductCategory>>>> GetProducts()
        {
            var response = new Response<List<ProductCategory>>();
            var list = await _productCategoryRepository.GetAllAsync();
            response.Data = list;
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Response<ProductCategory>>> SaveProduct([FromBody] ProductCategory productCategory)
        {
            var response = new Response<ProductCategory>();
            response.Data = await _productCategoryRepository.SaveAsync(productCategory);
            return Created($"/api/[controller]/{productCategory.Id}",response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<ProductCategory>>> GetProductById(int id)
        {
            var product = await _productCategoryRepository.GetByIdAsync(id);
            var respose = new Response<ProductCategory>();
            if (product == null)
            {
                respose.Message = "Not Found";
                return NotFound(respose);
            }
            respose.Data = product;
            return Ok(respose);
        }

        [HttpPut]
        public async Task<ActionResult<Response<ProductCategory>>> UpdateProduct(ProductCategory product)
        {
            return Ok(new Response<ProductCategory>() { Data = await _productCategoryRepository.UpdateAsync(product) });
        }
    }
}
