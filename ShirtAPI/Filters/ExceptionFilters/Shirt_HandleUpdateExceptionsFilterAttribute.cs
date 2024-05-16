using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShirtAPI.Data;

namespace ShirtAPI.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strId, out int Id))
            {
                if (ShirtStore.ShirtExists(Id))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist anymore");
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
