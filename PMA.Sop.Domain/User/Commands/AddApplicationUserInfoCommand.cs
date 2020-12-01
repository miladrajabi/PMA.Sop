using System;
using PMA.Sop.Framework.Commands;

namespace PMA.Sop.Domain.User.Commands
{
    public class AddApplicationUserInfoCommand : ICommand
    {
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }
    }
}