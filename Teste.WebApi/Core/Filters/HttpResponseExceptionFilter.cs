using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Teste.WebApi.Core.Filters
{
    internal class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is Exception exception)
            {
                var error =
                    new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest
                    };

                context.Result = new ObjectResult(error) { StatusCode = StatusCodes.Status400BadRequest };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}