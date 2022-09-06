using _01_LampshadeQuery.Contracts.ProductCategory;
using _01_LampshadeQuery.Contracts.Slide;
using _01_LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Infrastructure.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagmentBoostrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();

            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();

            service.AddTransient<ISlideRepository, SlideRepository>();
            service.AddTransient<ISlideApplication, SlideApplication>();

            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();


            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}