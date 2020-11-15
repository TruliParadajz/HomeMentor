using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shared.ErrorHandling
{
    public class ApiException : Exception
    {
        public HttpStatusCode ResponseCode { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public ApiException()
        {

        }

        public ApiException(string message) : base(message)
        {

        }

        public ApiException(string message, HttpStatusCode responseCode) : base(message)
        {
            ResponseCode = responseCode;
        }

        public ApiException(string message, HttpStatusCode responseCode, ErrorCode errorCode) : base(message)
        {
            ResponseCode = responseCode;
            ErrorCode = errorCode;
        }
    }
}
