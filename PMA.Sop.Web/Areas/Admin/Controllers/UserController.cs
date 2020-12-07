using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PMA.Sop.ApplicationServices.DTOs.User;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserController(IMediator mediator, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListUser()
        {
            var user = _userManager.Users.Select(x => new UserDto()
            {
                RegisterDate = x.RegisteredDate.GetValueOrDefault().ToString("yyyy/MM/dd"),
                Id = x.Id,
                Email = x.Email

            }).ToList();
            return View(user);
        }

    }
}
