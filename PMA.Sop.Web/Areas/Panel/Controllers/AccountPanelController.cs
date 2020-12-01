using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Queries;
using PMA.Sop.Framework.Resources.Interface;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Panel.Controllers
{

    [Area(nameof(Panel))]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class AccountPanelController : BaseController
    {
        public AccountPanelController(IResourceManager resourceManager, CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher) : base(resourceManager, commandDispatcher, queryDispatcher)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddApplicationUserInfo()
        {
            return View();
        }



    }
}
