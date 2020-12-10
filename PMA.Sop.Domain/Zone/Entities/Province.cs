using System.Collections.Generic;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Zone.Entities
{
    public class Province : BaseHcEntity<long>
    {
        public int ZoneId { get; set; }

        #region Relations
        public virtual Zone Zone { get; set; }
        public ICollection<District> District { get; set; }
        #endregion

    }
}