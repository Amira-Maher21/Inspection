//using Microsoft.AspNetCore.Http;
//using System.Net;
//using System.Text.Json;

//namespace Inspection.Application.Shared.GlobalExceptionHandler
//{
//    public class GlobalExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public GlobalExceptionMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (BusinessException ex)
//            {
//                context.Response.StatusCode = (int)ex.StatusCode;
//                context.Response.ContentType = "application/json";

//                await context.Response.WriteAsync(JsonSerializer.Serialize(new
//                {
//                    message = ex.Message,
//                    errors = ex.Errors
//                }));
//            }
//            catch (Exception)
//            {
//                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                context.Response.ContentType = "application/json";

//                await context.Response.WriteAsync(JsonSerializer.Serialize(new
//                {
//                    message = "Unexpected error occurred"
//                }));
//            }
//        }
//    }
//}
