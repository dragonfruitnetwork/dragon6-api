// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Data.Serializers.Newtonsoft;
using DragonFruit.Six.Api.Services.Geolocation.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Services.Geolocation
{
    public static class GeolocationExtensions
    {
        /// <summary>
        /// Get the current device location based on a IP Geolocation lookup
        /// </summary>
        public static Task<Geolocation> GeolocateAsync<T>(this T client) where T : ApiClient<ApiJsonSerializer>
        {
            return client.PerformAsync<Geolocation>(new UbisoftSelfGeolocationRequest());
        }

        /// <summary>
        /// Get the approximate location and ISP info for a collection of IP addresses
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="ips">A collection of IP addresses to lookup</param>
        /// <returns>An <see cref="IReadOnlyCollection{T}"/> containing the IP addresses and their approximate location</returns>
        public static async Task<IReadOnlyCollection<Geolocation>> GeolocateAsync(this Dragon6Client client, params string[] ips)
        {
            var request = new UbisoftGeolocationRequest(ips);
            var container = await client.PerformAsync<JObject>(request).ConfigureAwait(false);

            return container["ipLocations"]?.ToObject<Geolocation[]>() ?? Array.Empty<Geolocation>();
        }

        /// <summary>
        /// Get the approximate location and ISP info for a collection of IP addresses
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="ips">A collection of IP addresses to lookup</param>
        /// <returns>An <see cref="IReadOnlyCollection{T}"/> containing the IP addresses and their approximate location</returns>
        public static Task<IReadOnlyCollection<Geolocation>> GeolocateAsync(this Dragon6Client client, params IPAddress[] ips)
        {
            return GeolocateAsync(client, ips.Select(x => x.ToString()).ToArray());
        }
    }
}
