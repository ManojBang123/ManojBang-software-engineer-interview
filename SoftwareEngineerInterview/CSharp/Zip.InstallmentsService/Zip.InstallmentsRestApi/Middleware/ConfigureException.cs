namespace Zip.InstallmentsRestApi.Middleware
{
    /// <summary>
    /// To add Exception Middleware to use custom middleware with custom exception message
    /// </summary>
    public static class ConfigureException
    {
        public static void ConfigureCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
