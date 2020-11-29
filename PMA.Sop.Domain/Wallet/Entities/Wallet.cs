using System;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Wallet.Entities
{
    public class Wallet : BaseEntity
    {
        public long WalletTypeId { get; set; }
        public int ApplicationUserId { get; set; }
        public bool IsPay { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        #region Relations
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual WalletType WalletType { get; set; }
        #endregion

    }
}