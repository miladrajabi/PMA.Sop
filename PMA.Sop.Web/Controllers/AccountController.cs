using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PMA.Sop.Core.DTOs.User;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto register)
        {
            if (!ModelState.IsValid) return View(register);

            var model = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                EmailConfirmed = false
            };
            var res = await _userManager.CreateAsync(model, register.Password);
            if (res.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            foreach (var err in res.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View();
        }
    }
}
