using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Zone.Entities
{
    public class District : BaseHcEntity<long>
    {
        public int ProvinceId { get; set; }

        #region relations
        public virtual Province Province { get; set; }
        public virtual ApplicationUserAddress ApplicationUserAddress { get; set; }
        #endregion
    }
}