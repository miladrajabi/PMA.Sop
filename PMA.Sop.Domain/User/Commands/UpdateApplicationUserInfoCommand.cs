using System;
using MediatR;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Dtos;

namespace PMA.Sop.Domain.User.Commands
{
    public class UpdateApplicationUserInfoCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }
    }
}