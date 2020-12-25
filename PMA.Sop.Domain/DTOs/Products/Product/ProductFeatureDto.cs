using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Products.Product
{
    public class ProductFeatureDto
    {
        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_200)]
        //[Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_200)]
        [DisplayName(SharedResource.EnglishTitle)]
        public string EnglishTitle { get; set; }

        [MaxLength(1500, ErrorMessage = SharedResource.MaxLength_256)]
        //[Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Description)]
        public string Description { get; set; }

    }
}