using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace PMA.Sop.Framework.Web
{
    public class BaseController : Controller
    {
        protected readonly IMediator Mediator;
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

    }
}