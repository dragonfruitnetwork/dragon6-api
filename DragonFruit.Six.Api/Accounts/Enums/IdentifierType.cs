// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Accounts.Enums
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
