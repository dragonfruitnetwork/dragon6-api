// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    /// <summary>
    /// A token model used to authenticate requests against the ubisoft api
    /// </summary>
    public interface IUbisoftToken
    {
        string Token { get; }
        string SessionId { get; }

        DateTime Expiry { get; }
    }
}
