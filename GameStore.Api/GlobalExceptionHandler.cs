using GameStore.Domain.Common.Models;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

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