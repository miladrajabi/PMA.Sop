using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Role
{
    public class RoleListDto
    {
        public int Id { get; set; }

        [DisplayName(SharedResource.Title)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Name { get; set; }

        [DisplayName(SharedResource.Description)]
        public string Description { get; set; }

        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
    }
}