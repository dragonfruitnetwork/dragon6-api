// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Data.Requests
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
        protected string PlatformValue => PlatformParser.PlatformIdentifierFor(Platform);

        [QueryParameter("nameOnPlatform")]
        protected string PlayerNames => LookupMethod == LookupMethod.Name ? string.Join(",", LookupQuery) : null;

        [QueryParameter("idOnPlatform")]
        protected string PlatformIds => LookupMethod == LookupMethod.PlatformId ? string.Join(",", LookupQuery) : null;

        [QueryParameter("userId")]
        protected string UbisoftIds => LookupMethod == LookupMethod.UserId ? string.Join(",", LookupQuery) : null;
    }
}
