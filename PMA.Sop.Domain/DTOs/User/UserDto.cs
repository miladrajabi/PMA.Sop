using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.User
{
    public class UserDto : BaseModelDto<long>
    {
        [DisplayName(SharedResource.Email)]
        [Required(ErrorMessage = SharedResource.Email)]
        public string Email { get; set; }

        public string RegisterDate { get; set; }

        public List<string> Roles { get; set; }

    }
}
