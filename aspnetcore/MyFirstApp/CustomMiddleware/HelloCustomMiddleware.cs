using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstApp.CustomMiddleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class HelloCustomMiddleware
{
    private readonly RequestDelegate _next;

    public HelloCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        //before
        if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
        {
            string fullName = $"{httpContext.Request.Query["firstname"]} {httpContext.Request.Query["lastname"]}\n";
            await httpContext.Response.WriteAsync($"Hello, {fullName}. Welcome to Software Development!\n");
        }

        await _next(httpContext);
        //after
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class HelloCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HelloCustomMiddleware>();
    }
}
