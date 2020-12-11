using System.ComponentModel.DataAnnotations.Schema;
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
