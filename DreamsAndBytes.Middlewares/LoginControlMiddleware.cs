using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DreamsAndBytes.Middlewares
{
    public class LoginControlMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var nameIdentifierClaim = httpContext.User.Claims.ToList().FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (nameIdentifierClaim != null && nameIdentifierClaim.Value != null && nameIdentifierClaim.Value != string.Empty)
            {
                httpContext.Response.Redirect("/Login/Index");
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}
