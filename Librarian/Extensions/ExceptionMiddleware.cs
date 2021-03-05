using Librarian.Models;
using Librarian.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ILoggerInterface loggerInterface)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, loggerInterface);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception, ILoggerInterface loggerInterface)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        loggerInterface.LogToDb(new ExceptionViewModel
        {
            ExceptionMsg = exception.Message,
            ExceptionSource = exception.Source,
            ExceptionType = exception.GetType().ToString(),
            ExceptionURL = exception.StackTrace.ToString()
        });
        return context.Response.WriteAsync(new
        {
            context.Response.StatusCode,
            Message = "Internal Server Error from the custom middleware."
        }.ToString());
    }
}