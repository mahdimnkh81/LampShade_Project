using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagement.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductController(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        [HttpGet]
        public List<ProductCategoryQueryModel> GetLatestArrivals()
        {
            return _productCategoryQuery.GetProductCategories();
        }
    }
}