using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PMA.Sop.Web.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public IActionResult Index(bool? isSuccess = null)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
    }
}
