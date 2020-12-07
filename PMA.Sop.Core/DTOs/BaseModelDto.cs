using System;

namespace PMA.Sop.ApplicationServices.DTOs
{
    public class BaseModelDto<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatorUserId { get; set; }
        public int? ModifiedId { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
}
