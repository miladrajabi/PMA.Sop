using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PMA.Sop.Domain.User.ViewModel
{
    public class GetApplicationUserInfoVM
    {
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }
    }
}