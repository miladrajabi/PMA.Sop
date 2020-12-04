using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.ApplicationServices.DTOs.User
{
    public class ApplicationUserInfoDto
    {
        [DisplayName()]
        public int ApplicationUserId { get; set; }

        [DisplayName(SharedResource.FirstName)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string FirstName { get; set; }

        [DisplayName(SharedResource.LastName)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string LastName { get; set; }

        [DisplayName(SharedResource.NationalCode)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string NationalCode { get; set; }

        [DisplayName(SharedResource.Birthdate)]
        public DateTime? Birthdate { get; set; }

        [DisplayName(SharedResource.Sex)]
        public string Gender { get; set; }
    }
}