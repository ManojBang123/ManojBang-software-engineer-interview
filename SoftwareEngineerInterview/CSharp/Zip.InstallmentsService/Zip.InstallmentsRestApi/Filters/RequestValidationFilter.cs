using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsRestApi.Filters
{
    /// <summary>
    /// This is action filter to filter the error messsages received during the request validation 
    /// </summary>
    public class RequestValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           if (!context.ModelState.IsValid)
            {
                var validtaionerrors = new ValidationErrors();
                var result = from modelstate in context.ModelState
                             where modelstate.Value.Errors.Any()
                             let fieldKey = modelstate.Key
                             let errors = modelstate.Value.Errors
                             from error in errors
                             select new Error(fieldKey, error.ErrorMessage);

                validtaionerrors.Errors = result.ToList();
                validtaionerrors.Title = "One Or More Error Occured";
                validtaionerrors.StatusCode = 400;
                context.HttpContext.Response.StatusCode = validtaionerrors.StatusCode;
                context.Result = new JsonResult(validtaionerrors);

            }
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

     
    }
}
