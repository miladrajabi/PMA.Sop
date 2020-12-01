using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PMA.Sop.Domain.User.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Column(TypeName = "DateTime")]
        public DateTime? RegisteredDate { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedDate { get; set; }

        #region Relations

        public virtual List<Wallet.Entities.Wallet> Wallets { get; set; }

        public virtual ApplicationUserInfo ApplicationUserInfo { get; set; }

        public ICollection<ApplicationUserAddress> ApplicationUserAddress { get; set; }

        #endregion

    }
}