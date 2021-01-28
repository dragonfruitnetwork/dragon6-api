// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.Api.Requests.Base;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public class AccountInfoRequest : UbiApiRequest
    {
        public override string Path => Endpoints.IdServer;

        public AccountInfoRequest()
        {
        }

        public AccountInfoRequest(Platform platform, LookupMethod lookupMethod, string query)
        {
            Platform = platform;
            LookupMethod = lookupMethod;

            LookupQuery = new[] { query };
        }

        public AccountInfoRequest(Platform platform, LookupMethod lookupMethod, IEnumerable<string> queries)
        {
            Platform = platform;
            LookupMethod = lookupMethod;

            LookupQuery = queries;
        }

        /// <summary>
        /// The platform the query is to be checked against
        /// </summary>
        public Platform Platform { get; set; }

        /// <summary>
        /// The type of query provided
        /// </summary>
        public LookupMethod LookupMethod { get; set; }

        /// <summary>
        /// The queries
        /// </summary>
        public IEnumerable<string> LookupQuery { get; set; }

        [QueryParameter("platformType")]
        private string PlatformValue => PlatformParser.PlatformIdentifierFor(Platform);

        [QueryParameter("nameOnPlatform", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> PlayerNames => LookupMethod == LookupMethod.Name ? LookupQuery : null;

        [QueryParameter("idOnPlatform", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> PlatformIds => LookupMethod == LookupMethod.PlatformId ? LookupQuery : null;

        [QueryParameter("userId", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> UbisoftIds => LookupMethod == LookupMethod.UserId ? LookupQuery : null;
    }
}
