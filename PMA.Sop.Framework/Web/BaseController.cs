using Microsoft.AspNetCore.Mvc;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Queries;
using PMA.Sop.Framework.Resources.Interface;

namespace PMA.Sop.Framework.Web
{
    public class BaseController : Controller
    {
        protected readonly CommandDispatcher CommandDispatcher;
        protected readonly IResourceManager ResourceManager;
        protected readonly QueryDispatcher QueryDispatcher;

        protected BaseController(IResourceManager resourceManager, CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            ResourceManager = resourceManager;
            CommandDispatcher = commandDispatcher;
            QueryDispatcher = queryDispatcher;
        }

        protected BaseController()
        {
            ;
        }
    }
}