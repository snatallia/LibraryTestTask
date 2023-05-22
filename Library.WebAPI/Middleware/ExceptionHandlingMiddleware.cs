using System;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using FluentValidation;


using Library.Application.Common.Exceptions;
using FluentValidation.Results;

namespace Library.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {  
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {     
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {   
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception)
        => exception switch
        { 
                ValidationException=> StatusCodes.Status422UnprocessableEntity,
                BadHttpRequestException =>StatusCodes.Status400BadRequest,
                EntityNotFoundException => StatusCodes.Status404NotFound,
                _=> StatusCodes.Status500InternalServerError
        };

        private static IEnumerable<ValidationFailure> GetErrors(Exception exception)
        {
            IEnumerable<ValidationFailure> errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            return errors;
        }

      
    }
}
