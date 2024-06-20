using System.Diagnostics;
using System.Text.Json;
using GameStore.Application.Common;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameStore;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, errorMessage) = exception switch
        {
            NotFoundException notFoundException => (404, notFoundException.Message),
            _ => (500, "Something went wrong")
        };
        
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Message = errorMessage
        };
        
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}