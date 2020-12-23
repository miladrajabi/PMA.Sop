using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMA.Sop.Domain.DTOs.Products.Categories;
using PMA.Sop.Domain.Product.Commands.Categories;
using PMA.Sop.Domain.Product.Queries.Categories;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CategoryController : BaseController<ApplicationUser>
    {
        public CategoryController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator, userManager)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var pr = await Mediator.Send(new GetCategoryQueries());
            var model = new CreateCategoryDto
            {
                Parent = pr.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var command = new CategoryCreateCommand()
            {
                CreateDate = DateTime.Now,
                CreatorUserId = (await CurrentUser()).Id,
                Icon = model.Icon,
                ParentId = model.ParentId > 0 ? model.ParentId : null,
                Title = model.Title

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
