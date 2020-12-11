using MediatR;
using PMA.Sop.Framework.Dtos;

namespace PMA.Sop.Domain.Product.Commands.Brands
{
    public class BrandCreateCommand : IRequest<ResultDto>
    {
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }
        public string Src { get; set; }
    }
}