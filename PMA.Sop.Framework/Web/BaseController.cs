using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace PMA.Sop.Framework.Web
{
    public class BaseController<T> : Controller where T : class
    {
        private readonly ICollection<string> _errors = new List<string>();
        protected readonly UserManager<T> UserManager;
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator, UserManager<T> userManager)
        {
            Mediator = mediator;
            UserManager = userManager;
        }

        protected bool ResponseHasErrors(ValidationResult result)
        {
            if (result == null || result.IsValid) return false;

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }

            return true;
        }
        protected void AddProcessError(string error)
        {
            _errors.Add(error);
        }

        protected bool IsValidOperation()
        {
            return !_errors.Any();
        }
        protected async Task<T> CurrentUser()
        {
            var user = await UserManager.GetUserAsync(User);
            return user;
        }
    }
}