using System.ComponentModel;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Products
{
    public class GetBrandDto
    {
        public int Id { get; set; }
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [DisplayName(SharedResource.EnglishTitle)]
        public string EnglishTitle { get; set; }

        [DisplayName(SharedResource.ShortDescription)]
        public string Description { get; set; }

        [DisplayName(SharedResource.File)]
        public string Src { get; set; }
        public int Count { get; set; }
    }
}