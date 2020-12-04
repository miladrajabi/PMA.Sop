using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Sop.ApplicationServices.DTOs
{
    public class BaseModelDto
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? CreatorUserId { get; set; }
        public int? ModifiedId { get; set; }

        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
}
