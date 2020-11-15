using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shared.ErrorHandling
{
    public class ApiError
    {
        public ErrorCode ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Details { get; set; }

        public ApiError(ErrorCode errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public ApiError(ErrorCode errorCode, string errorDescription, HttpStatusCode statusCode)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            StatusCode = statusCode;
        }

        public ApiError(ErrorCode errorCode, string errorDescription, HttpStatusCode statusCode, string details)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            StatusCode = statusCode;
            Details = details;
        }
    }
}
