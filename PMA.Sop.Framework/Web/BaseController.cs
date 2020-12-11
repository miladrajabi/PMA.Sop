using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation.Results;

namespace PMA.Sop.Framework.Web
{
    public class BaseController : Controller
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected readonly IMediator Mediator;
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
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

        public bool IsValidOperation()
        {
            return !_errors.Any();
        }
    }
}