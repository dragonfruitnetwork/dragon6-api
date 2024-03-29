﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Authentication.Entities;

namespace DragonFruit.Six.Api.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(IUbisoftToken token)
            : base("The Token has expired or is invalid for this request")
        {
            Token = token;
        }

        public InvalidTokenException(string token)
            : base("The Token has expired or is invalid for this request")
        {
            Token = new Dragon6Token
            {
                Token = token
            };
        }

        public IUbisoftToken Token { get; }
    }
}
