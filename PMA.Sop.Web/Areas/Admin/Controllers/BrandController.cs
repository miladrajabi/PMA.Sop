using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PMA.Sop.Domain.DTOs.Products;
using PMA.Sop.Domain.Product.Commands.Brands;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class BrandController : BaseController
    {
        public BrandController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateBrandDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto model)
        {
            if (!ModelState.IsValid) return View(new CreateBrandDto());
            var command = new BrandCreateCommand()
            {
                Description = model.Description,
                EnglishTitle = model.EnglishTitle,
                Src = model.Src,
                Title = model.Title
            };
            var res = await Mediator.Send(command);

            if (res.IsSuccess)
                return RedirectToAction(nameof(Index));
            foreach (var itemError in res.Errors)
                ModelState.AddModelError("", itemError);
            return View(model);

        }

    }
}
