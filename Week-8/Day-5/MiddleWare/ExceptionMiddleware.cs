using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");

            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new ErrorResponse
        {
            Timestamp = DateTime.UtcNow
        };

        switch (exception)
        {
            case NotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = exception.Message;
                break;

            case BadRequestException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = exception.Message;
                break;

            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Something went wrong";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode;

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}