// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Enums
{
    /// <summary>
    /// Describes how the server should interpret the search queries provided in the request
    /// </summary>
    public enum IdentifierType
    {
        /// <summary>
        /// Player's name
        /// </summary>
        Name,

        /// <summary>
        /// The User ID, which is global across different ubi games
        /// </summary>
        UserId,

        /// <summary>
        /// Id on the platform, not always the same as the GUID
        /// </summary>
        PlatformId
    }
}
