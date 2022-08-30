using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        public IProductCategoryRepository _ProductCategoryRepository { get; set; }

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _ProductCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var Operation = new OperationResult();
            if (_ProductCategoryRepository.Exists(x => x.Name == command.Name))
            {
                return Operation.Failed("امکان ثبت رکورد تکراری وجود ندارد.دوباره سعی کنید");
            }

            var slug = GenerateSlug.Slugify(command.Slug);
            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture,
                command.PictureTitle, command.PictureAlt, slug, command.Keywords, command.MetaDescription);
            _ProductCategoryRepository.Create(productCategory);
            _ProductCategoryRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _ProductCategoryRepository.Get(command.Id);
            if (productCategory == null)
            {
                return operation.Failed("همچین رکوردی وجود ندارد ");
            }

            if (_ProductCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد.دوباره سعی کنید");
            }

            var slug = GenerateSlug.Slugify(command.Slug);
            productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureTitle,
                command.PictureAlt, slug, command.Keywords, command.MetaDescription);
            _ProductCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            return _ProductCategoryRepository.Search(command);
        }

        public EditProductCategory GetDetails(long id)
        {
            return _ProductCategoryRepository.GetDetails(id);
        }
    }
}