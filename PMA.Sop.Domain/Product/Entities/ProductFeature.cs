using PMA.Sop.Domain.Common;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Product.Entities
{
    public class ProductFeature : BaseUserEntity<long>
    {
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }

        #region Relationships
        public virtual Product Product { get; set; }
        #endregion
    }
}