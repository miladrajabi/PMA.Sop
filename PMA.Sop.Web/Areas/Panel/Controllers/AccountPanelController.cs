using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using PMA.Sop.ApplicationServices.DTOs.User;
using PMA.Sop.Core.DTOs.User;
using PMA.Sop.Domain.User.Commands;
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
        public AccountPanelController(IResourceManager resourceManager, CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IMediator mediator) : base(resourceManager, commandDispatcher, queryDispatcher, mediator)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddApplicationUserInfo()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            var _userId = Convert.ToInt16(claim?.Value);
            return View(new ApplicationUserInfoDto() { ApplicationUserId = _userId });
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicationUserInfo(ApplicationUserInfoDto model)
        {
            bool? gender = null;
            if (model.Gender.ToLower() == "male")
            {
                gender = true;
            }
            else if (model.Gender.ToLower() == "male")
            {
                gender = false;
            }
            if (!ModelState.IsValid) return View(model);
            var command = new AddApplicationUserInfoCommand()
            {
                CreateDate = DateTime.Now,
                CreatorUserId = model.ApplicationUserId,
                Gender = gender,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Birthdate = model.Birthdate,
                ApplicationUserId = model.ApplicationUserId,
                NationalCode = model.NationalCode
            };
            //var result = CommandDispatcher.Dispatch(new AddApplicationUserInfoCommand()
            //{
            //    CreateDate = DateTime.Now,
            //    CreatorUserId = model.ApplicationUserId,
            //    Gender = gender,
            //    LastName = model.LastName,
            //    FirstName = model.FirstName,
            //    Birthdate = model.Birthdate,
            //    ApplicationUserId = model.ApplicationUserId,
            //    NationalCode = model.NationalCode
            //});
            var res = await Mediator.Send(command);
            if (res > 0)
            {

                return RedirectToAction("Index");
            }
            //ModelState.AddModelError("", result.Message);
            //foreach (var item in result.Errors)
            //{
            //    ModelState.AddModelError("", item);
            //}
            return View(model);
        }



    }
}
