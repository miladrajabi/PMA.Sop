using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.ApplicationServices.DTOs.User
{
    public class LoginUserDto
    {
        [DisplayName(SharedResource.Email)]
        [EmailAddress(ErrorMessage = SharedResource.EmailError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName(SharedResource.Password)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class ResetPasswordDto
    {
        [DataType(DataType.Password)]
        [DisplayName(SharedResource.Password)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName(SharedResource.RePassword)]
        [Compare(nameof(Password), ErrorMessage = SharedResource.RePasswordError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string RePassword { get; set; }

        public string UserId { get; set; }
        public string TokenId { get; set; }
    }
}
