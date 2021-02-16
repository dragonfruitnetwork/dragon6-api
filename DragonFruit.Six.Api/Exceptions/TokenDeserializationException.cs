// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Exceptions
{
    public class TokenDeserializationException : Exception
    {
        public TokenDeserializationException()
            : base("Failed to produce a token from the source provided")
        {
        }
    }
}
