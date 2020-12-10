using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Common
{
    public class BaseUserEntity<T> : BaseEntity<T>
    {
        [ForeignKey(nameof(CreatorUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
