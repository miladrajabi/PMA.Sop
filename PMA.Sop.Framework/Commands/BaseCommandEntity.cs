using System;

namespace PMA.Sop.Framework.Commands
{
    public class BaseCommandEntity
    {

        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? CreatorUserId { get; set; }
        public int? ModifiedId { get; set; }

        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
}