// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Accounts.Requests
{
    public class UbisoftAccountRequest : UbiApiRequest
    {
        public override string Path => Endpoints.IdServer;

        /// <summary>
        /// Creates a <see cref="UbisoftAccountRequest"/> targeting a single user
        /// </summary>
        public UbisoftAccountRequest(string query, Platform platform, IdentifierType identifierType)
            : this(query.Yield(), platform, identifierType)
        {
        }

        /// <summary>
        /// Creates a <see cref="UbisoftAccountRequest"/> targeting multiple users on the same <see cref="Platform"/>
        /// </summary>
        public UbisoftAccountRequest(IEnumerable<string> queries, Platform platform, IdentifierType identifierType)
        {
            Platform = platform;
            IdentifierType = identifierType;

            Identifiers = queries;
        }

        /// <summary>
        /// The <see cref="Platform"/> to search users for
        /// </summary>
        public Platform Platform { get; set; }

        /// <summary>
        /// The type of query provided
        /// </summary>
        public IdentifierType IdentifierType { get; set; }

        /// <summary>
        /// The account identifiers to use when searching for accounts
        /// </summary>
        public IEnumerable<string> Identifiers { get; set; }

        [QueryParameter("platformType")]
        private string PlatformValue => PlatformParser.PlatformIdentifierFor(Platform);

        [QueryParameter("nameOnPlatform", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> PlayerNames => LookupString(IdentifierType.Name);

        [QueryParameter("idOnPlatform", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> PlatformIds => LookupString(IdentifierType.PlatformId);

        [QueryParameter("userId", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> UbisoftIds => LookupString(IdentifierType.UserId);

        private IEnumerable<string> LookupString(IdentifierType method) => IdentifierType == method ? Identifiers : null;
    }
}
