using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.ApplicationServices.Specifications;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Domain.User.Commands;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.User.Repositories;

namespace PMA.Sop.ApplicationServices.User.Command
{
    public class UserInfoCommandHandler : IRequestHandler<AddApplicationUserInfoCommand, int>, IRequestHandler<UpdateApplicationUserInfoCommand, int>
    {
        private readonly IApplicationUserInfoCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserInfoCommandHandler(IApplicationUserInfoCommandRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddApplicationUserInfoCommand request, CancellationToken cancellationToken)
        {

            var model = new ApplicationUserInfo()
            {
                CreateDate = request.CreateDate,
                CreatorUserId = request.ApplicationUserId,
                Gender = request.Gender,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Birthdate = request.Birthdate,
                ApplicationUserId = request.ApplicationUserId,
                NationalCode = request.NationalCode
            };
            await _repository.AddAsync(model);
            var res = await _unitOfWork.CommitAsync(cancellationToken);
            return res;
        }

        public async Task<int> Handle(UpdateApplicationUserInfoCommand request, CancellationToken cancellationToken)
        {
            var rec = await _repository.FirstOrDefaultAsync(
                new ApplicationUserInfoSpecification(request.ModifiedId.GetValueOrDefault()));
            _repository.UpdateRep(rec, request);
            var res = await _unitOfWork.CommitAsync(cancellationToken);
            return res;
        }
    }
}