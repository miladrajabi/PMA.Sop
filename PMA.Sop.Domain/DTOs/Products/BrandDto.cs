using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Products
{
    public class CreateBrandDto
    {
        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_256)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_256)]
        [DisplayName(SharedResource.EnglishTitle)]
        public string EnglishTitle { get; set; }


        [MaxLength(500, ErrorMessage = SharedResource.MaxLength_256)]
        [DisplayName(SharedResource.ShortDescription)]

        public string Description { get; set; }

        public string Src { get; set; }

        [DisplayName(SharedResource.File)]
        public IFormFile File { get; set; }
    }
}