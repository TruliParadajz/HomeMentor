using Microsoft.AspNetCore.Builder;
using Shared.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Extensions
{
    public static class GeneralExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
