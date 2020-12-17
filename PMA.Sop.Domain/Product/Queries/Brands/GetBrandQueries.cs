
using System.Collections.Generic;
using MediatR;
using PMA.Sop.Domain.DTOs;
using PMA.Sop.Domain.DTOs.Products;

namespace PMA.Sop.Domain.Product.Queries.Brands
{
    public class GetBrandQueries : BaseQueries, IRequest<IReadOnlyList<GetBrandDto>>
    {

    }
}