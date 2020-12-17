using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PMA.Sop.Domain.DTOs.Products;
using PMA.Sop.Domain.Product.Commands.Brands;
using PMA.Sop.Domain.Product.Queries.Brands;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Common.Interfaces;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class BrandController : BaseController<ApplicationUser>
    {
        private readonly string brandFilePath = @"file\images\brands";
        private readonly IFileHandler _fileHandler;

        public BrandController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator, userManager)
        {
        }
        public async Task<IActionResult> Index()
        {
            var cmd = await Mediator.Send(new GetBrandQueries());
            return View(cmd);
        }

        [HttpPost]
        public async Task<IActionResult> List()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var pageSize = length != null ? Convert.ToInt32(length) : 0;
            var skip = start != null ? Convert.ToInt32(start) : 0;

            var cmd = await Mediator.Send(new GetBrandQueries { PageSize = pageSize, SearchKey = searchValue, Skip = skip, SortColumn = sortColumn, SortDirection = sortColumnDirection });
            var recordsTotal = cmd?.FirstOrDefault()?.Count;
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = cmd };
            return Ok(jsonData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateBrandDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.File != null)
            {
                var file = await _fileHandler.UploadFileAsync(model.File, brandFilePath);
                model.Src = file.Status ? file.FileNameAddress : null;
            }
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
