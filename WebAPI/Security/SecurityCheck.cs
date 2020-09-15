using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPIDemo
{
    public class SecurityCheck
    {
        private readonly RequestDelegate _next;

        public SecurityCheck(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return _next(httpContext);
        }

    }

    public static class SecurityCheckExtensions
    {
        public static IApplicationBuilder UseSecurityCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecurityCheck>();
        }
    }
}