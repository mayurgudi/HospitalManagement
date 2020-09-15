using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Security
{
    public class LoginAction
    {
        private readonly RequestDelegate _next;

        public LoginAction(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return _next(httpContext);
        }
    }

    public static class LoginActionExtensions
    {
        public static IApplicationBuilder UseLoginAction(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginAction>();
        }
    }
}
