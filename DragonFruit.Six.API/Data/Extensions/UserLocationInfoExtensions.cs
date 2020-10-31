// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data.Requests;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class UserLocationInfoExtensions
    {
        /// <summary>
        /// Get the user's IP address and info from the ubisoft servers
        /// </summary>
        public static UserLocationInfo GetUserLocationInfo<T>(this T client) where T : Dragon6Client
        {
            var request = new UserLocationInfoRequest();
            return client.Perform<UserLocationInfo>(request);
        }
    }
}
