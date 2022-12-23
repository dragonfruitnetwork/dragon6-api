// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Net;

namespace DragonFruit.Six.Api.Exceptions
{
    public class UbisoftErrorException : Exception
    {
        public UbisoftErrorException(HttpStatusCode code, string message)
            : base($"Ubisoft returned an error: {code} - {message}")
        {
        }
    }
}
