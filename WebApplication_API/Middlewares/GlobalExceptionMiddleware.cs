

using System.Diagnostics;

namespace WebApplication_API.Middlewares;

public class GlobalExceptionMiddleware
{
    private RequestDelegate next;
    ILogger<GlobalExceptionMiddleware> logger;
    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError("Eccezione non gestita");
            await HandleException(ex, context);
        }
    }

    private static Task HandleException(Exception ex, HttpContext context)
    {
        var (statusCode, title) = ex switch
        {
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource not Found"),
            InvalidProgramException => (StatusCodes.Status406NotAcceptable, "Invalid Operation"),
            ValidationException => (StatusCodes.Status400BadRequest, "Bad Request"),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error"),
        };

        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;


        var problemaDetails = new ProblemDetails()
        {
            Status = statusCode,
            Detail = ex.Message,
            Title = title,
            Instance = context.Request.Path,
        };

        problemaDetails.Extensions["TRACEID"] = traceId;

        return context.Response.WriteAsJsonAsync(problemaDetails);
    }
}
