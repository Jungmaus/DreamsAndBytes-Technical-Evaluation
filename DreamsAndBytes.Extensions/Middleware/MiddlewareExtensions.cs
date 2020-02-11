using DreamsAndBytes.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCultureMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<CultureMiddleware>();
        public static IApplicationBuilder UseLoginControlMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<LoginControlMiddleware>();
    }
}
