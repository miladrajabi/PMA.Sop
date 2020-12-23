using PMA.Sop.Domain.DTOs.Products.Product;

namespace PMA.Sop.Web.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public ProductDto ProductDto { get; set; }
        public ProductFeatureDto ProductFeatureDto { get; set; }
    }
}