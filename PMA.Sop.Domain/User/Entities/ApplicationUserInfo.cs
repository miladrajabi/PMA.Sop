using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.User.Entities
{
    public class ApplicationUserInfo : BaseEntity
    {
        public int ApplicationUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? Birthdate { get; set; }

        public bool? Gender { get; set; }

        #region Relations
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion
    }
}