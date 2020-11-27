using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PMA.Sop.Core.DTOs.User;
using PMA.Sop.Core.Services.Interface;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View(new RegisterUserDto());
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserDto register)
        {
            if (!ModelState.IsValid) return View(register);

            var user = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                EmailConfirmed = false
            };
            var res = await _userManager.CreateAsync(user, register.Password);
            if (res.Succeeded)
            {
                if (user.EmailConfirmed)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                    {
                        UserId = user.Id,
                        token = token
                    }, protocol: Request.Scheme);
                    var body = $"لطفا برای فعال حساب کاربری بر روی لینک زیر کلیک کنید!  <br/> <a href={callbackUrl}> Link </a>";
                    await _emailService.Execute(user.Email, body, "فعال سازی حساب کاربری");
                    return RedirectToAction(nameof(DisplayEmail));
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            foreach (var err in res.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View();
        }

        public IActionResult DisplayEmail()
        {
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

        public async Task<IActionResult> ConfirmEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
                return BadRequest();
            var user = _userManager.FindByIdAsync(UserId).Result;
            if (user == null)
                return RedirectToAction(nameof(Login));

            var result = await _userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index), "Home");
            return RedirectToAction("login");

        }

    }
}
