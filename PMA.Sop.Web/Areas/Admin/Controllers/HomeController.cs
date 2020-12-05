using Microsoft.AspNetCore.Mvc;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Route("{area:exists}/{controller=Home}/{action=Index}/{id?}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
