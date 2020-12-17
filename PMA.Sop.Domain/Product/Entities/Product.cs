using System.Collections.Generic;
using PMA.Sop.Domain.Common;

namespace PMA.Sop.Domain.Product.Entities
{
    public class Product : BaseUserEntity<long>
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Color { get; set; }
        public decimal PriceDiscount { get; set; }
        public int Discount { get; set; }
        public bool Displayed { get; set; } = true;
        public bool CanPurchase { get; set; } = true;
        public int Quantity { get; set; }

        public long BrandId { get; set; }

        #region Relationships
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public ICollection<ProductTechnical> ProductTechnicals { get; set; }
        #endregion
    }
}