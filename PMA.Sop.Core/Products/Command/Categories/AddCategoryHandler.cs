using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.Domain.Product.Commands.Categories;
using PMA.Sop.Domain.Product.Entities;
using PMA.Sop.Domain.Product.Repositories.Categories;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Framework.Dtos;
using PMA.Sop.Framework.Resources.Interface;

namespace PMA.Sop.ApplicationServices.Products.Command.Categories
{
    public class AddCategoryHandler : IRequestHandler<CategoryCreateCommand, ResultDto>
    {
        private readonly ICategoryCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;
        private readonly ResultDto _result;

        public AddCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IResourceManager resourceManager, ICategoryCommandRepository repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceManager = resourceManager;
            _result = new ResultDto(_resourceManager);
            _repository = repository;
        }

        public async Task<ResultDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var mapper = new Category
            {
                CreateDate = request.CreateDate,
                CreatorUserId = request.CreatorUserId,
                ParentId = request.ParentId,
                Title = request.Title,
                Icon = request.Icon,
            };
            await _repository.AddAsync(mapper);
            _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
            return _result;
        }
    }
}
