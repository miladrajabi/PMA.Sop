using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PMA.Sop.Core.DTOs.User;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
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
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(model);

                return RedirectToAction(nameof(Index), "Home");
            }
            foreach (var err in res.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View();
        }

        [Route("Login")]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginUserDto() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto log)
        {
            var userIdentity = User.Identity;
            if (userIdentity != null && userIdentity.IsAuthenticated)
                return RedirectToAction(nameof(Index), "Home");

            if (!ModelState.IsValid) return View(log);
            var user = await _userManager.FindByEmailAsync(log.Email);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var tryCount = user.AccessFailedCount;
                var lockUser = tryCount >= 5;
                var res = await _signInManager.PasswordSignInAsync(user, log.Password, log.RememberMe, lockUser);
                if (res.Succeeded)
                {
                    return Redirect(log.ReturnUrl ?? "/");
                }

                if (res.RequiresTwoFactor)
                {
                    //redirect to page twofactor
                }
                if (res.IsLockedOut)
                {
                    //redirect to page IsLockedOut
                }
            }
            else
            {
                ModelState.AddModelError(nameof(log.Email), "Invalid UserName or Password");
            }
            return View(log);
        }

        [Route("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
