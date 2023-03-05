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
            // some logic

            Debug.WriteLine("-- MyCustomMiddleware before --");

            await this.next(context);

            Debug.WriteLine("-- MyCustomMiddleware after --");
        }
    }
}
