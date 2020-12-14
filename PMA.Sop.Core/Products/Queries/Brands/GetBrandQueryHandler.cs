using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.ApplicationServices.Specifications.Products;
using PMA.Sop.Domain.DTOs.Products;
using PMA.Sop.Domain.Product.Queries.Brands;
using PMA.Sop.Domain.Product.Repositories.Brands;

namespace PMA.Sop.ApplicationServices.Products.Queries.Brands
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQueries, IReadOnlyList<GetBrandDto>>
    {
        private readonly IBrandsCommandRepository _repository;
        private readonly IMapper _mapper;

        public GetBrandQueryHandler(IBrandsCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetBrandDto>> Handle(GetBrandQueries request,
            CancellationToken cancellationToken)
        {
            //var  spc=new BrandSpecification();
            //var q = spc.BrandList(request.Skip, request.PageSize, request.SearchKey, request.SortColumn);
            var query = await _repository.ListAllAsync(true);
            //var query = await _repository.ListAsync(
            //    new BrandSpecification(request.Skip, request.PageSize, request.SearchKey, request.SortColumn), true);
            //var count = await _repository.CountAsync(new BrandSpecification(request.Skip, request.PageSize,
            //    request.SearchKey, request.SortColumn));

            var lst = query?.Select(x => new GetBrandDto()
            {
                Description = x.Description,
                EnglishTitle = x.EnglishTitle,
                Src = x.Src,
                Title = x.Title,
                //Count = count
            }).ToList().AsReadOnly();
            return lst;
        }
    }
}