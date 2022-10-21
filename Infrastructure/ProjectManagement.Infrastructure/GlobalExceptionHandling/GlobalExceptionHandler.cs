using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace ProjectManagement.Infrastructure.GlobalExceptionHandling
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            var responseModel = new ExceptionResponseModel();

            switch (exception)
            {
                case ApplicationException:
                    responseModel.ResponseCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.ResponseMessage = "Application Exception Occured! Please retry after sometime.";
                    break;
                case FileNotFoundException:
                    responseModel.ResponseCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.ResponseMessage = "The request resource is not found!";
                    break;

                default:
                    responseModel.ResponseCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.ResponseMessage = "Internal Server Error! Please retry after sometime.";
                    break;
            }

            var exResult = JsonSerializer.Serialize(responseModel);
            await context.Response.WriteAsync(exResult);
        }
    }
}
