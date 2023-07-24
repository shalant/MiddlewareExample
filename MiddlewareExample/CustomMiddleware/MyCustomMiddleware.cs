using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - Ends\n");

        }
    }

    public static class CustomMiddlewareExtension
    {
        //what is an extension method? a method injected into an object dynamically
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
