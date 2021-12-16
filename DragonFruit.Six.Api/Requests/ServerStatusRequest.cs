// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public class ServerStatusRequest : ApiRequest
    {
        public override string Path => "https://game-status-api.ubisoft.com/v1/instances";

        /// <summary>
        /// Initialises a <see cref="ServerStatusRequest" /> for all siege platforms
        /// </summary>
        public ServerStatusRequest()
            : this(UbisoftIdentifiers.GameIds.Keys)
        {
        }

        /// <inheritdoc />
        public ServerStatusRequest(params string[] appIds)
            : this((IEnumerable<string>)appIds)
        {
        }

        /// <summary>
        /// Initialises a <see cref="ServerStatusRequest"/> for the app ids provided
        /// </summary>
        public ServerStatusRequest(IEnumerable<string> appIds)
        {
            AppIds = appIds;
        }

        [QueryParameter("appIds", CollectionConversionMode.Concatenated)]
        public IEnumerable<string> AppIds { get; set; }
    }
}
