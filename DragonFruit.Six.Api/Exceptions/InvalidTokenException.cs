// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Tokens;

namespace DragonFruit.Six.Api.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(TokenBase token)
            : base("The Token Provided has expired or is invalid")
        {
            Token = token;
        }

        public TokenBase Token { get; }
    }
}
