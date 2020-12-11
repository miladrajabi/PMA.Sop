using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.Domain.Product.Commands.Brands;
using PMA.Sop.Domain.Product.Entities;
using PMA.Sop.Domain.Product.Repositories.Brands;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Framework.Dtos;
using PMA.Sop.Framework.Resources.Interface;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.ApplicationServices.Products.Command.Brands
{
    public class AddBrandHandler : IRequestHandler<BrandCreateCommand, ResultDto>
    {

        private readonly IBrandsCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;
        private readonly ResultDto _result;

        public AddBrandHandler(IBrandsCommandRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IResourceManager resourceManager)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceManager = resourceManager;
            _result = new ResultDto(_resourceManager);
        }

        public async Task<ResultDto> Handle(BrandCreateCommand request, CancellationToken cancellationToken )
        {
            if (await IsValid(request))
            {
                var mapper = new Brand()
                {
                    Description = request.Description,
                    EnglishTitle = request.EnglishTitle,
                    Remarks = request.Remarks,
                    Src = request.Src,
                    Title = request.Title
                };
                await _repository.AddAsync(mapper);
                _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
            }

            return _result;
        }

        private async Task<bool> IsValid(BrandCreateCommand request)
        {
            var isUnique = await _repository.IsUniqueBrandAsync(request.Title);

            if (!isUnique)
            {
                _result.AddError(SharedResource.IsNotUnique, "");
                _result.IsSuccess = false;
            }

            return _result.IsSuccess;
        }
    }
}