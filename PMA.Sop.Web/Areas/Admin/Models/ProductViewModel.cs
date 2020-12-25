using System.Collections.Generic;
using PMA.Sop.Domain.DTOs.Products.Product;

namespace PMA.Sop.Web.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public ProductDto ProductDto { get; set; }
        public List<ProductFeatureDto> ProductFeatureDto { get; set; }
    }
}