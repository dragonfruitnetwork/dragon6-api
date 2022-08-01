// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;

namespace DragonFruit.Six.Api.Services.Geolocation.Requests
{
    /// <summary>
    /// Creates a request to get the approximate location a collection of provided IP addresses
    /// </summary>
    public class UbisoftGeolocationRequest : UbiApiRequest
    {
        public override string Path => $"{Endpoints.BaseEndpoint}/v2/iplocation";

        public UbisoftGeolocationRequest(IEnumerable<string> addresses)
        {
            Addresses = addresses;
        }

        [QueryParameter("ips", CollectionConversionMode.Concatenated)]
        public IEnumerable<string> Addresses { get; }
    }
}
