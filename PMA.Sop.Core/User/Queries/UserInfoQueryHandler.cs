using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.ApplicationServices.Specifications;
using PMA.Sop.Domain.User.Queries;
using PMA.Sop.Domain.User.Repositories;
using PMA.Sop.Domain.User.ViewModel;

namespace PMA.Sop.ApplicationServices.User.Queries
{
    public class UserInfoQueryHandler : IRequestHandler<GetApplicationUserInfoQuery, GetApplicationUserInfoVM>
    {

        private readonly IApplicationUserInfoCommandRepository _repository;
        private readonly IMapper _mapper;

        public UserInfoQueryHandler(IApplicationUserInfoCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetApplicationUserInfoVM> Handle(GetApplicationUserInfoQuery request, CancellationToken cancellationToken)
        {
            var rec = await _repository.FirstOrDefaultAsync(
                new ApplicationUserInfoSpecification(request.ApplicationUserId));
            return new GetApplicationUserInfoVM()
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