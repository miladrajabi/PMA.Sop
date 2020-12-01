using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMA.Sop.Framework.Domain
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatorUserId { get; set; }
        public int? ModifiedId { get; set; }

        public bool IsRemoved { get; set; } = false;

        [Column(TypeName = "DateTime")]
        public DateTime? RemoveTime { get; set; }

    }
}