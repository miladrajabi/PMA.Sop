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

    }
}