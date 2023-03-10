using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetPipelines.Middlewares
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        [HttpGet]
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Reffered-From", "some-cool-app.com");
            Debug.WriteLine("-- MyCustomMiddleware before --");
            if (!context.Request.Headers.ContainsKey("Reffered-From") ||
                !context.Request.Headers["Reffered-From"].ToString().Contains("some-cool-app.com"))
            {
                context.Response.StatusCode = 403; // Forbidden
                return;
            }

            await this.next(context);

            Debug.WriteLine("-- MyCustomMiddleware after --");
        }
    }
}
