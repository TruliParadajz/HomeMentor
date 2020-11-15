using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Net;
using Shared.Enums;
using Newtonsoft.Json;

namespace Shared.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private const string CONTENT_TYPE = "application/content";

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentException ex)
            {
                httpContext.Response.ContentType = CONTENT_TYPE;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var error = new ApiError(ErrorCode.ArgumentNullException, ex.Message, HttpStatusCode.BadRequest);

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
            catch (ApiException ex)
            {
                httpContext.Response.ContentType = CONTENT_TYPE;
                httpContext.Response.StatusCode = (int)ex.ResponseCode;
                var error = new ApiError(ErrorCode.ApiException, ex.Message, HttpStatusCode.BadRequest, ex.Data.ToString());

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));

            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = CONTENT_TYPE;
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var error = new ApiError(ErrorCode.ArgumentNullException, "Unexpected error has occured.", HttpStatusCode.BadRequest);

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));

            }
        }
    }
}
