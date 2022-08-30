using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure;
using ShopManagement.Infrastructure.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagmentBoostrapper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddTransient<IProductCategoryApplication,ProductCategoryApplication>();
            

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));

        }
    }
}