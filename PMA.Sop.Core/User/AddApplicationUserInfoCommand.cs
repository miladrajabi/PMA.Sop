using System.Threading.Tasks;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Domain.User.Commands;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.User.Repositories;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Resources.Interface;

namespace PMA.Sop.Core.User
{
    public class ApplicationUserInfoCommandHandler : CommandHandler<AddApplicationUserInfoCommand>
    {

        private readonly IApplicationUserInfoCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationUserInfoCommandHandler(IResourceManager resourceManager, IApplicationUserInfoCommandRepository repository, IUnitOfWork unitOfWork) : base(resourceManager)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public override CommandResult Handle(AddApplicationUserInfoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<CommandResult> HandleAsync(AddApplicationUserInfoCommand command)
        {
            var model = new ApplicationUserInfo();
            await _repository.AddAsync(model);
            var res = await _unitOfWork.CommitAsync();
            return res > 0 ? Ok() : Failure();
        }
    }
}