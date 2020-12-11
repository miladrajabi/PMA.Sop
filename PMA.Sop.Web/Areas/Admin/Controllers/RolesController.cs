using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.Domain.DTOs.Role;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class RolesController : BaseController
    {

        private readonly RoleManager<ApplicationRole> _roleManager;
        public RolesController(IMediator mediator, RoleManager<ApplicationRole> roleManager) : base(mediator)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int? pageSize = null)
        {
            var role = await _roleManager.Roles.AsNoTracking().Select(x => new RoleListDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
            
            return View(role);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RolesAddDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesAddDto model)
        {
            var role = new ApplicationRole()
            {
                Name = model.Name,
                Description = model.Description
            };
            var res = await _roleManager.CreateAsync(role);
            if (res.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var err in res.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View(model);
        }

    }
}
