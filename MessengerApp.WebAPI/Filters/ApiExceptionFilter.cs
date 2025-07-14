using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MessengerApp.WebAPI.Filters;

public class ApiExceptionFilter() : IExceptionFilter
{

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var response = new
        {
            Message = "An unexpected error occurred.",
            Details = exception.Message
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };

        context.ExceptionHandled = true;
    }
}