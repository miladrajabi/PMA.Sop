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
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserController(IMediator mediator, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) : base(mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var user = _userManager.Users.Select(x => new UserDto
            {
                RegisterDate = x.RegisteredDate.GetValueOrDefault().EnglishToPersian("$yyyy/$MM/$dd"),
                Id = x.Id,
                Email = x.Email
            }).ToList();
            return View(user);
        }

        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.AsNoTracking().Select(x => new SelectListItem()
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
            return View(model);
        }
    }
}
