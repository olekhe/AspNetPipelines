namespace AspNetPipelines.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder application)
        {
            return application.UseMiddleware<MyCustomMiddleware>();
        }
    }

  
}
