using _0_Framework.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }


        public OperationResult Create(CreateArticleCategory command)
        {
           var operationResult = new OperationResult();
           if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
               return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
           var slug = command.Slug.Slugify();
           var pictureName = _fileUploader.Upload(command.Picture, slug);
           var articleCategory = new ArticleCategory(command.Name, pictureName, command.PictureAlt, command.PictureTitle
               , command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription,
               command.CanonicalAddress);
           _articleCategoryRepository.Create(articleCategory);
           _articleCategoryRepository.SaveChanges();
           return operationResult.Succedded();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operationResult = new OperationResult();
            var editArticleCategory = _articleCategoryRepository.Get(command.Id);
            if (editArticleCategory == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            editArticleCategory.Edit(command.Name,pictureName,command.PictureAlt,
                command.PictureTitle,command.Description,command.ShowOrder,slug,command.Keywords
                ,command.MetaDescription,command.CanonicalAddress);
            _articleCategoryRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }
    }
}