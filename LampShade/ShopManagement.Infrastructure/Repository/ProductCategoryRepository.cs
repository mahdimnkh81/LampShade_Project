using System.Linq.Expressions;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;


namespace ShopManagement.Infrastructure.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        public ShopContext _Context { get; set; }

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }


        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _Context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _Context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug,
                Keywords = x.Keywords,
                PictureAlt = x.PictureAlt,
                MetaDescription = x.MetaDescription,
                // Picture = x.Picture,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetCategorySlugBy(long id)
        {
            return _Context.ProductCategories.Select(x => new { x.Slug, x.Id }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            var query = _Context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
                Picture = x.Picture,
            });
            if (!string.IsNullOrEmpty(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}