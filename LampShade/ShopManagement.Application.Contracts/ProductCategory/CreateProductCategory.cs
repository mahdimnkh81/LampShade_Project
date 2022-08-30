using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(500,ErrorMessage = ValidationMessages.MaxLenght)] public string Description { get; set; }
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLenght)] public string Picture { get; set; }
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)] public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        [MaxLength(300, ErrorMessage = ValidationMessages.MaxLenght)] public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLenght)]
        public string MetaDescription { get; set; }
    }
}