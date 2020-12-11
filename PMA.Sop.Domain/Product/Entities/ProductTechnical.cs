using PMA.Sop.Domain.Common;

namespace PMA.Sop.Domain.Product.Entities
{
    public class ProductTechnical : BaseUserEntity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }

        #region Relationships
        public virtual Product Product { get; set; }

        #endregion
    }
}