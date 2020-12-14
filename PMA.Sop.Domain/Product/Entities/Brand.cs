using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMA.Sop.Domain.Interfaces;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Product.Entities
{
    public class Brand : BaseHcEntity<int>, IAggregateRoot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }

        public ICollection<Product> Products { get; set; }
        public string Src { get; set; }
    }
}