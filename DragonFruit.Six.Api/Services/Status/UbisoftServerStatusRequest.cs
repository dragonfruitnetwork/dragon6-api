// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Requests;

namespace DragonFruit.Six.Api.Services.Status
{
    public class UbisoftServerStatusRequest : ApiRequest
    {
        public override string Path => "https://game-status-api.ubisoft.com/v1/instances";

        /// <summary>
        /// Initialises a <see cref="ServerStatusRequest" /> for all siege platforms
        /// </summary>
        public UbisoftServerStatusRequest()
            : this(UbisoftIdentifiers.GameIds.Keys)
        {
        }

        /// <inheritdoc />
        public UbisoftServerStatusRequest(params string[] appIds)
            : this((IEnumerable<string>)appIds)
        {
        }

        /// <summary>
        /// Initialises a <see cref="UbisoftServerStatusRequest"/> for the app ids provided
        /// </summary>
        public UbisoftServerStatusRequest(IEnumerable<string> appIds)
        {
            AppIds = appIds;
        }

        [QueryParameter("appIds", CollectionConversionMode.Concatenated)]
        public IEnumerable<string> AppIds { get; set; }
    }
}
