using System.Collections.Generic;
using MediatR;
using PMA.Sop.Domain.DTOs;
using PMA.Sop.Domain.DTOs.Products;
using PMA.Sop.Domain.DTOs.Products.Categories;

namespace PMA.Sop.Domain.Product.Queries.Categories
{
    public class GetCategoryQueries : BaseQueries, IRequest<IReadOnlyList<GetCategoryDto>>
    {

    }
}