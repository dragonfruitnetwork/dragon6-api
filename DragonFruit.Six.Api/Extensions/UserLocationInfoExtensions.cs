// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests;

namespace DragonFruit.Six.Api.Extensions
{
    public static class UserLocationInfoExtensions
    {
        /// <summary>
        /// Get the user's IP address and info from the ubisoft servers
        /// </summary>
        public static UserLocationInfo Geolocate(this ApiClient client, CancellationToken token = default)
        {
            var request = new GeolocationRequest();
            return client.Perform<UserLocationInfo>(request, token);
        }

        /// <summary>
        /// Get the user's IP address and info from the ubisoft servers
        /// </summary>
        public static Task<UserLocationInfo> GeolocateAsync(this ApiClient client, CancellationToken token = default)
        {
            var request = new GeolocationRequest();
            return client.PerformAsync<UserLocationInfo>(request, token);
        }
    }
}
