using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class HomeController : BaseController<ApplicationUser>
    {

        public HomeController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator, userManager)
        {
        }

        //[Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
        //[Route("[area]/[controller]/[action]")]
        public IActionResult Index2()
        {
            return View();
        }

    }
}
