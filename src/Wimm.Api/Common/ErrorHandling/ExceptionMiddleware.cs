using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

namespace Wimm.Api.Common.ErrorHandling;

internal sealed class ExceptionMiddleware
{
    private const string ContentType = "application/json";
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = ContentType;

        var statusCode = (int)HttpStatusCode.InternalServerError;
        var message = exception.Message;

        context.Response.StatusCode = statusCode;

        var result = JsonSerializer.Serialize(new ProblemDetails
        {
            Type = "generic-exception",
            Title = "An error occurred in the application",
            Status = statusCode,
            Detail = message,
            Instance = exception.Source,
        });

        await context.Response.WriteAsync(result);
    }
}