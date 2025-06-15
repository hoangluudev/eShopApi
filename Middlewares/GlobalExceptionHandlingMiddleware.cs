// eShopApi/Middlewares/GlobalExceptionHandlingMiddleware.cs
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Đảm bảo đã có namespace này

namespace eShopApi.Middlewares
{
    // Thay đổi từ (ILogger logger) thành (ILogger<GlobalExceptionHandlingMiddleware> logger)
    public class GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) : IMiddleware
    {
        // Bây giờ _logger đã là ILogger<GlobalExceptionHandlingMiddleware> trực tiếp
        // Không cần ép kiểu nữa, chỉ cần gán
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An unhandled exception occurred: {ErrorMessage}", e.Message); // Tối ưu message log
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Internal Server Error",
                    Title = "Internal Server Error",
                    Detail = "Something went wrong.",
                };
                string json = JsonSerializer.Serialize(problem);
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}