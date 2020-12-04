using System;
using System.ComponentModel.DataAnnotations.Schema;
using PMA.Sop.Domain.Zone.Entities;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.User.Entities
{
    public class ApplicationUserAddress : BaseEntity<long>
    {
        public int ApplicationUserId { get; set; }

        public string PostCode { get; set; }
        public string Plaque { get; set; }
        public string Unit { get; set; }
        public string PostalAddress { get; set; }
        public bool RecipientIsSelf { get; set; }

        [ForeignKey(name: nameof(District))]
        public long DistrictId { get; set; }

        #region Recipient

        public string RecipientFirstName { get; set; }
        public string RecipientLastName { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string RecipientNationalCode { get; set; }
        #endregion

        #region  RelationShips

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual District District { get; set; }

        #endregion
    }
}