using System.Net;
using Newtonsoft.Json;

namespace Newman.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            switch (ex.GetType().Name)
            {
                case "NotFoundException":
                    code = HttpStatusCode.NotFound;
                    break;
                case "DuplicateException":
                case "OverlappingDateException":
                    code = HttpStatusCode.Conflict;
                    break;
                case "NoAccessException":
                    code = HttpStatusCode.Forbidden;
                    break;
                case "NotAuthenticatedException":
                    code = HttpStatusCode.Unauthorized;
                    break;
                case "GenericException":
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
