namespace Wimm.Api.Common.ErrorHandling;

internal static class ErrorHandlingModule
{
    internal static IApplicationBuilder UseErrorHandling(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        return applicationBuilder;
    }
}