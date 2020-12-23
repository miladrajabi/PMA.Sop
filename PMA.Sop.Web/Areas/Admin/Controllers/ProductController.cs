using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMA.Sop.Domain.DTOs.Products.Product;
using PMA.Sop.Domain.Product.Commands.Brands;
using PMA.Sop.Domain.Product.Commands.Products;
using PMA.Sop.Domain.Product.Queries.Brands;
using PMA.Sop.Domain.Product.Queries.Categories;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;
using PMA.Sop.Web.Areas.Admin.Models;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : BaseController<ApplicationUser>
    {
        public ProductController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator, userManager)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await Mediator.Send(new GetCategoryQueries());
            var brands = await Mediator.Send(new GetBrandQueries());

            var model = new ProductViewModel()
            {
                ProductDto = new ProductDto()
                {
                    Category = categories.Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Title.ToString()
                    }).ToList(),
                    Brand = brands.Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Title.ToString()
                    }).ToList(),
                },
                ProductFeatureDto = new ProductFeatureDto()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model, string editor1)
        {
            if (!ModelState.IsValid) return View(model);
            var command = new ProductsCreateCommand
            {
                Title = model.ProductDto.Title,
                EnglishTitle = model.ProductDto.EnglishTitle,
                Code = model.ProductDto.Code,
                Discount = model.ProductDto.Discount,
                PriceDiscount = model.ProductDto.PriceDiscount,
                Price = model.ProductDto.Price,
                Quantity = model.ProductDto.Quantity,
                CategoryId = model.ProductDto.CategoryId,
                BrandId = model.ProductDto.BrandId,
                CanPurchase = model.ProductDto.CanPurchase,
                Displayed = model.ProductDto.Displayed,
                Description = editor1,

                ProductImages = new List<ProductImagesCommand>(),
                ProductFeatures = new List<ProductFeaturesCommand>(),
                ProductTechnician = new List<ProductTechnicalCommand>()

            };
            var res = await Mediator.Send(command);
            if (res.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }
    }
}
