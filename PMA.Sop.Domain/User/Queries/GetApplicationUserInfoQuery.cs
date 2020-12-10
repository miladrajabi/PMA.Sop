using System;
using MediatR;
using PMA.Sop.Domain.DTOs.User;

namespace PMA.Sop.Domain.User.Queries
{
    public class GetApplicationUserInfoQuery : IRequest<ApplicationUserInfoDto>
    {
        public int ApplicationUserId { get; set; }
    }
}