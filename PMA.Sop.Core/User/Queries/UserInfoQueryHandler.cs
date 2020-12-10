using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.ApplicationServices.Specifications;
using PMA.Sop.Domain.DTOs.User;
using PMA.Sop.Domain.User.Queries;
using PMA.Sop.Domain.User.Repositories;

namespace PMA.Sop.ApplicationServices.User.Queries
{
    public class UserInfoQueryHandler : IRequestHandler<GetApplicationUserInfoQuery, ApplicationUserInfoDto>
    {

        private readonly IApplicationUserInfoCommandRepository _repository;
        private readonly IMapper _mapper;

        public UserInfoQueryHandler(IApplicationUserInfoCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApplicationUserInfoDto> Handle(GetApplicationUserInfoQuery request, CancellationToken cancellationToken)
        {
            var rec = await _repository.FirstOrDefaultAsync(
                new ApplicationUserInfoSpecification(request.ApplicationUserId));
            return new ApplicationUserInfoDto()
            {
                ApplicationUserId = rec.ApplicationUserId,
                FirstName = rec.FirstName,
                LastName = rec.LastName,
                NationalCode = rec.NationalCode,
                Birthdate = rec.Birthdate,
                Gender = rec.Gender,
            };
        }
    }
}