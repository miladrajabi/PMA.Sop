using System;
using MediatR;
using PMA.Sop.Framework.Commands;

namespace PMA.Sop.Domain.User.Commands
{
    public class UpdateApplicationUserInfoCommand : BaseCommandEntity, IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }
    }
}