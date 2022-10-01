using System.Linq.Expressions;
using System.Net.Sockets;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(long id);
        string GetCategorySlugBy(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel categorySearchModel);
    }
}