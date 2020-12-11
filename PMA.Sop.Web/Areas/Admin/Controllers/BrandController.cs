using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        public BrandController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
