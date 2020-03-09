using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Tour.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            context.HttpContext.Response.WriteAsync("{\"messege\": \"sth went wrong\",\"more_info\":\"contact us\"}");
            context.ExceptionHandled = true;
        }
    }
}