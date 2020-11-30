using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Panel.Controllers
{
    [Area(nameof(Panel))]
    [Route("[area]/[controller]/[action]")]
    public class WalletController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
