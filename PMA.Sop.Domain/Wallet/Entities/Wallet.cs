using System;
using System.ComponentModel.DataAnnotations.Schema;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Wallet.Entities
{
    public class Wallet : BaseEntity<long>
    {
        public long WalletTypeId { get; set; }
        public int ApplicationUserId { get; set; }
        public bool IsPay { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        #region Relations
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual WalletType WalletType { get; set; }
        #endregion

    }
}