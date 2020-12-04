using Microsoft.AspNetCore.Mvc;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Queries;
using PMA.Sop.Framework.Resources.Interface;
using Microsoft.AspNetCore.Authorization;
using MediatR;

namespace PMA.Sop.Framework.Web
{
    public class BaseController : Controller
    {
        protected readonly CommandDispatcher CommandDispatcher;
        protected readonly IResourceManager ResourceManager;
        protected readonly QueryDispatcher QueryDispatcher;

        protected IMediator Mediator;


        protected BaseController(IResourceManager resourceManager, CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IMediator mediator)
        {
            ResourceManager = resourceManager;
            CommandDispatcher = commandDispatcher;
            QueryDispatcher = queryDispatcher;
            Mediator = mediator;
        }

        protected BaseController(IResourceManager resourceManager, CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            throw new System.NotImplementedException();
        }
    }
}