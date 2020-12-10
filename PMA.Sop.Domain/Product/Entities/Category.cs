﻿using System.Collections.Generic;
using PMA.Sop.Domain.Common;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.Domain.Product.Entities
{
    public class Category : BaseUserEntity<long>
    {
        public string Title { get; set; }

        public long? ParentId { get; set; }
        public string Icon { get; set; }

        public int ProductId { get; set; }

        #region Relationships
        public ICollection<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }

        #endregion
    }
}