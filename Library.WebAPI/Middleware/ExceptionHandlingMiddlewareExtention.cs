namespace Library.WebAPI.Middleware
{
    public static class ExceptionHandlingMiddlewareExtention
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
