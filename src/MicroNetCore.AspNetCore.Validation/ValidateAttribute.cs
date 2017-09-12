using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroNetCore.AspNetCore.Validation
{
    public sealed class ValidateAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            context.Result = new BadRequestResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}