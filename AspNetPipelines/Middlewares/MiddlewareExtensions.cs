namespace AspNetPipelines.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder application)
        {
            return application.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
