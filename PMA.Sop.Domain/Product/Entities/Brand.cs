using System.Collections.Generic;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Product.Entities
{
    public class Brand : BaseHcEntity<int>
    {
        public ICollection<Product> Products { get; set; }
        public string Src { get; set; }
    }
}