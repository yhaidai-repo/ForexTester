using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Common.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError("An error occurred {message}", ex.Message);

            var response = context.Response;

            response.StatusCode = StatusCodes.Status404NotFound;

            await response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred {message}", ex.Message);

            var response = context.Response;

            response.StatusCode = StatusCodes.Status500InternalServerError;

            await response.WriteAsync(ex.Message);

            return;
        }
    }
}
