using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Core.DTOs.User
{
    public class LoginUserDto
    {
        [EmailAddress(ErrorMessage = SharedResource.EmailError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
