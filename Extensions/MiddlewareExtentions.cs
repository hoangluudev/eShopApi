using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopApi.Middlewares;

namespace eShopApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        }
        public static IApplicationBuilder UseGlobal404RouteHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Global404RouteHandler>();
        }
    }
}