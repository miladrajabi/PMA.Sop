using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.User
{
    public class ForgetPasswordDto
    {
        [DisplayName(SharedResource.Email)]
        [EmailAddress(ErrorMessage = SharedResource.EmailError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Email { get; set; }
    }
}