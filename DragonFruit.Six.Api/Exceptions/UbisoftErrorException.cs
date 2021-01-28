// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Exceptions
{
    public class UbisoftErrorException : Exception
    {
        public UbisoftErrorException()
            : base("A Ubisoft server has disallowed this request, probably due to the Ubi-AppId header. Please check and try again")
        {
        }
    }
}
