using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using PMA.Sop.Domain.Product.Entities;

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

        public virtual UserInfo UserInfo { get; set; }

        public ICollection<UserAddress> UserAddress { get; set; }

        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public ICollection<Product.Entities.Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<ProductTechnical> ProductTechnicals { get; set; }

        #endregion

    }
}