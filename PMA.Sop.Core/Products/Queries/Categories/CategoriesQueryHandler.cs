using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.Domain.DTOs.Products.Categories;
using PMA.Sop.Domain.Product.Queries.Categories;
using PMA.Sop.Domain.Product.Repositories.Categories;

namespace PMA.Sop.ApplicationServices.Products.Queries.Categories
{
    public class CategoriesQueryHandler : IRequestHandler<GetCategoryQueries, IReadOnlyList<GetCategoryDto>>
    {
        private readonly ICategoryCommandRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesQueryHandler(ICategoryCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetCategoryDto>> Handle(GetCategoryQueries request, CancellationToken cancellationToken)
        {
            var query = await _repository.ListAllAsync(true);

            var lst = query.Select(x => new GetCategoryDto()
            {
                CreateDate = x.CreateDate,
                CreatorUserId = x.ModifiedId,
                ModifiedDate = x.ModifiedDate,
                IsRemoved = x.IsRemoved,
                ModifiedId = x.ModifiedId,
                RemoveTime = x.RemoveTime,

                Icon = x.Icon,
                Id = x.Id,
                ParentId = x.ParentId,
                Title = x.Title,

                Parent = x.Parent != null ? new GetCategoryDto()
                {
                    Id = x.Parent.Id,
                    Title = x.Parent.Title
                } : null,

            }).ToList().AsReadOnly();
            return lst;
        }
    }
}