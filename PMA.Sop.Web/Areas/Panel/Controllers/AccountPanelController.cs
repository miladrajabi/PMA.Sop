using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using PMA.Sop.Domain.DTOs.User;
using PMA.Sop.Domain.User.Commands;
using PMA.Sop.Domain.User.Queries;
using PMA.Sop.Framework.Web;

namespace PMA.Sop.Web.Areas.Panel.Controllers
{

    [Area(nameof(Panel))]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class AccountPanelController : BaseController
    {
        public AccountPanelController(IMediator mediator) : base(mediator)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddApplicationUserInfo()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            var _userId = Convert.ToInt16(claim?.Value);
            var model = new ApplicationUserInfoDto() { IsUpdated = false };
            var cmd = await Mediator.Send(new GetApplicationUserInfoQuery() { ApplicationUserId = _userId });
            if (cmd != null)
            {
                model.FirstName = cmd.FirstName;
                model.LastName = cmd.LastName;
                model.Birthdate = cmd.Birthdate;
                model.ApplicationUserId = cmd.ApplicationUserId;
                model.IsUpdated = true;

                if (cmd.Gender.GetValueOrDefault())
                {
                    model.GenderString = "Male";
                }
                else if (!cmd.Gender.GetValueOrDefault())
                {
                    model.GenderString = "Female";
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicationUserInfo(ApplicationUserInfoDto model)
        {
            bool? gender = null;
            var res = 0;
            gender = model.GenderString.ToLower() switch
            {
                "male" => true,
                "female" => false,
                _ => null
            };
            if (!ModelState.IsValid) return View(model);
            if (!model.IsUpdated)
            {
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
                res = await Mediator.Send(command);
            }
            else
            {
                var command = new UpdateApplicationUserInfoCommand()
                {
                    CreateDate = DateTime.Now,
                    CreatorUserId = model.ApplicationUserId,
                    Gender = gender,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Birthdate = model.Birthdate,
                    ModifiedId = model.ApplicationUserId
                };
                res = await Mediator.Send(command);
            }


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
