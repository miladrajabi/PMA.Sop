using MediatR;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Dtos;

namespace PMA.Sop.Domain.Product.Commands.Categories
{
    public class CategoryCreateCommand : BaseCommandEntity,  IRequest<ResultDto>
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
        public string Icon { get; set; }
    }
}