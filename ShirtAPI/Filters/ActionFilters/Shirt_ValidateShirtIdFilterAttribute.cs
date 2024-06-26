﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShirtAPI.Data;

namespace ShirtAPI.Filters.ActionFilters
{
    public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var Id = context.ActionArguments["id"] as int?;
            if (Id.HasValue)
            {
                if (Id.Value <= 0)
                {
                    context.ModelState.AddModelError("Id", "Shirt is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ShirtStore.ShirtExists(Id.Value))
                {
                    context.ModelState.AddModelError("Id", "shirt doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }




    }
}
