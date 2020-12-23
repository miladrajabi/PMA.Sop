using System.Collections.Generic;
using MediatR;
using PMA.Sop.Domain.Product.Commands.Brands;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Dtos;

namespace PMA.Sop.Domain.Product.Commands.Products
{
    public class ProductsCreateCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public decimal? PriceDiscount { get; set; }
        public int? Discount { get; set; }
        public bool Displayed { get; set; }
        public bool CanPurchase { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }

        public List<ProductImagesCommand> ProductImages { get; set; }
        public List<ProductFeaturesCommand> ProductFeatures { get; set; }
        public List<ProductTechnicalCommand> ProductTechnician { get; set; }

    }
}