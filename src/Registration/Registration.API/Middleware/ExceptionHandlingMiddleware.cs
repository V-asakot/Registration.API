using Registration.Application.Exceptions;
using System.Text.Json;
using Registration.Domain.Primitives;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registration.API.Middleware
{
    internal class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private const string defaultErrorMessage = "Internal error";
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var result = Result.Fail(GetErrors(exception));
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 200; // На прошлой работе возвращали из api Result объект с ошибкой вместо разных статусов,
                                                   // понятно такой подход не всем нравится 
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
       
        private static IEnumerable<string> GetErrors(Exception exception)
        {
            IEnumerable<string> errors = null;
            if (exception is ValidationException validationException)
                errors = validationException.ErrorsDictionary.Values.SelectMany(x => x);
            else errors = new[] { defaultErrorMessage }; //дефолтное сообщение вместо сообщения из exc других типов,
                                                         //фронту не стоит знать детали
            
            return errors;
        }
    }
}
