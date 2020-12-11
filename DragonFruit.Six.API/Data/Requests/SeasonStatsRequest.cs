// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;

#pragma warning disable 628

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class SeasonStatsRequest : PlatformSpecificRequest
    {
        public override string Path => Platform.SeasonalStatsEndpoint();

        public SeasonStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public SeasonStatsRequest(IEnumerable<AccountInfo> accounts, int seasonId)
            : base(accounts)
        {
            Season = seasonId;
        }

        public SeasonStatsRequest(IEnumerable<AccountInfo> accounts, int seasonId, string boardId)
            : base(accounts)
        {
            Season = seasonId;
            Board = boardId;
        }

        [QueryParameter("season_id")]
        public int Season { get; set; } = -1;

        [QueryParameter("board_id")]
        public string Board { get; set; } = "pvp_ranked";

        [QueryParameter("region_id")]
        public string Region { get; set; } = "EMEA";

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        internal override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
