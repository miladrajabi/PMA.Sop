using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.ApplicationServices.DTOs.User
{
    public class UserDto : BaseModelDto<long>
    {
        [DisplayName(SharedResource.Email)]
        [Required(ErrorMessage = SharedResource.Email)]
        public string Email { get; set; }

        public string RegisterDate { get; set; }

    }
}
