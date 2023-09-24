
using Ardalis.Result;
using System.Net;

namespace Shop.Api.Common;

public class ExceptionHandlerMiddleware : IMiddleware
{
    
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            // var exception = ex.Demystify();
            var exception = ex;

            _logger.LogError(exception, "An error ocurred: {Message}", exception.Message);
            HttpStatusCode code;
            switch (exception)
            {
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var result = Result.Error(exception.Message);
            // var result = Result.Error(exception.ToStringDemystified());

            await context.Response.WriteAsJsonAsync(result);
        }
    }
    
}