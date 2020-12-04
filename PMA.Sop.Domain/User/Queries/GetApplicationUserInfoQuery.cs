using System;
using MediatR;
using PMA.Sop.Domain.User.ViewModel;

namespace PMA.Sop.Domain.User.Queries
{
    public class GetApplicationUserInfoQuery : IRequest<GetApplicationUserInfoVM>
    {
        public int ApplicationUserId { get; set; }
    }
}