// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Helpers;

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

        public Platform Platform { get; set; }

        public LookupMethod LookupMethod { get; set; }

        public IEnumerable<string> LookupQuery { get; set; }

        [QueryParameter("platformType")]
        public string PlatformValue => PlatformParser.PlatformIdentifierFor(Platform);

        [QueryParameter("nameOnPlatform")]
        public string PlayerNames => LookupMethod == LookupMethod.Name ? string.Join(',', LookupQuery) : null;

        [QueryParameter("idOnPlatform")]
        public string PlatformIds => LookupMethod == LookupMethod.PlatformId ? string.Join(',', LookupQuery) : null;

        [QueryParameter("userId")]
        public string UbisoftIds => LookupMethod == LookupMethod.UserId ? string.Join(',', LookupQuery) : null;
    }
}
