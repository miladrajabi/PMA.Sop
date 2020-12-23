using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Products.Product
{
    public class ProductDto
    {
        [MaxLength(10, ErrorMessage = SharedResource.MaxLength_10)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Code)]
        public string Code { get; set; }

        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_200)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_200)]
        [DisplayName(SharedResource.EnglishTitle)]
        public string EnglishTitle { get; set; }

        [MaxLength(1500, ErrorMessage = SharedResource.MaxLength_256)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Description)]
        public string Description { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Price)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Color)]
        public string Color { get; set; }

        [DisplayName(SharedResource.PriceDiscount)]
        public decimal? PriceDiscount { get; set; }

        [DisplayName(SharedResource.Discount)]
        public int? Discount { get; set; }

        [DisplayName(SharedResource.Displayed)]
        public bool Displayed { get; set; } = true;

        [DisplayName(SharedResource.CanPurchase)]
        public bool CanPurchase { get; set; } = true;

        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Quantity)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Brand)]
        public long BrandId { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Category)]
        public long CategoryId { get; set; }

        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> Brand { get; set; }

    }
}