
using System.Collections.Generic;
using MediatR;
using PMA.Sop.Domain.DTOs.Products;

namespace PMA.Sop.Domain.Product.Queries.Brands
{
    public class GetBrandQueries :  IRequest<IReadOnlyList<GetBrandDto>>
    {
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public string SearchKey { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}