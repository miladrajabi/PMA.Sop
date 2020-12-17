using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.Domain.DTOs.User;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;
using SHPA.Common.Extension;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class UserController : BaseController<ApplicationUser>
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserController(IMediator mediator, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) : base(mediator, userManager)
        {
            //_userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {

            var user = UserManager.Users.Select(x => new UserDto
            {
                RegisterDate = x.RegisteredDate.GetValueOrDefault().EnglishToPersian("$yyyy/$MM/$dd"),
                Id = x.Id,
                Email = x.Email,
            }).ToList();

            foreach (var us in user)
            {
                us.Roles = (await UserManager.GetRolesAsync(UserManager.Users.FirstOrDefault(x => x.Id == us.Id))).ToList();
            }
            return View(user);
        }

        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.AsNoTracking().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            }).ToListAsync();
            var model = new AddUserDto()
            {
                ApplicationRoles = roles
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddUserDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = "Rajabi.meelad@gmail.com",
                RegisteredDate = DateTime.Now,

            };
            var res = await UserManager.CreateAsync(user, model.Password);

            if (res.Succeeded)
            {
                var roles = await _roleManager.Roles.Where(x => model.RoleIds.Contains(x.Id)).Select(x => x.Name).ToListAsync();
                var rolRes = await UserManager.AddToRolesAsync(user, roles);
                if (rolRes.Succeeded)
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
