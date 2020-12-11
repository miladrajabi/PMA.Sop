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
using PMA.Sop.Framework.Dtos;
using PMA.Sop.Framework.Resources.Interface;

namespace PMA.Sop.ApplicationServices.User.Command
{
    public class UserInfoCommandHandler : IRequestHandler<AddApplicationUserInfoCommand, ResultDto>, IRequestHandler<UpdateApplicationUserInfoCommand, ResultDto>
    {
        private readonly IApplicationUserInfoCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;


        public UserInfoCommandHandler(IApplicationUserInfoCommandRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IResourceManager resourceManager)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceManager = resourceManager;
        }

        public async Task<ResultDto> Handle(AddApplicationUserInfoCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultDto(_resourceManager) { IsSuccess = false };
            var model = new UserInfo()
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
            result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<ResultDto> Handle(UpdateApplicationUserInfoCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultDto(_resourceManager) { IsSuccess = false };

            var rec = await _repository.FirstOrDefaultAsync(
                new ApplicationUserInfoSpecification(request.ModifiedId.GetValueOrDefault()));
            if (rec != null)
            {
                _repository.UpdateRep(rec, request);
                result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
            }
            else
            {
                result.AddError("داده موجود نیست");
            }

            return result;
        }
    }
}