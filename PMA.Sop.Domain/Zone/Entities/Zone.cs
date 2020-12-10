using System.Collections.Generic;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Zone.Entities
{
    public class Zone : BaseHcEntity<long>
    {

        #region Relations
        public ICollection<Province> Province { get; set; }
        #endregion
    }
}