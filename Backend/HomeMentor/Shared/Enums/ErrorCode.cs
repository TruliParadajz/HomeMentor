using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Enums
{
    public enum ErrorCode
    {
        General = 0,
        NotFound = 1,
        OutOfBounds = 2,
        ArgumentNullException = 3,
        ApiException = 4
    }
}
