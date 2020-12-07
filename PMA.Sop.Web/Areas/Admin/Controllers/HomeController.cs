using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class HomeController : BaseController
    {

        public HomeController(IMediator mediator) : base(mediator)
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
