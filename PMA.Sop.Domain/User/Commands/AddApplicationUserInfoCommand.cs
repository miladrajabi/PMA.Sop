using System;
using MediatR;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Dtos;

namespace PMA.Sop.Domain.User.Commands
{
    public class AddApplicationUserInfoCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }
    }
}