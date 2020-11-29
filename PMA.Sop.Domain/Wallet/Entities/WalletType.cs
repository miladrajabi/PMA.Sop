using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Wallet.Entities
{
    public class WalletType : BaseEntity
    {
        public string TypeTitle { get; set; }

        #region Relations

        public virtual List<Wallet> Wallets { get; set; }


        #endregion
    }
}
