
namespace MyFirstApp.CustomMiddleware;

public class MyCustomerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("\nMy Custom Middleware");
        await next(context);
        await context.Response.WriteAsync("\nEND of Custom Middleware");
    }

}
public static class CustomMiddlewareExtension { 
    // extension method: injects into object directly

    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<MyCustomerMiddleware>();
        
    }
}

