// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Legacy.Requests;
using DragonFruit.Six.Api.Seasonal.Enums;

#pragma warning disable 628

namespace DragonFruit.Six.Api.Seasonal.Requests
{
    public sealed class SeasonalStatsRequest : PlatformSpecificRequest
    {
        public override string Path => $"{Platform.SandboxUrl()}/r6karma/players";

        /// <summary>
        /// Creates a seasonal stats request for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        public SeasonalStatsRequest(IEnumerable<UbisoftAccount> accounts, BoardType board = BoardType.Ranked, int season = -1, Region region = Region.EMEA)
            : base(accounts)
        {
            Board = board;
            Season = season;
            Region = region;
        }

        /// <summary>
        /// The leaderboard to return stats for
        /// </summary>
        public BoardType Board { get; set; }

        /// <summary>
        /// The season number (where <c>-1</c> is the current season)
        /// </summary>
        [QueryParameter("season_id")]
        public int Season { get; set; }

        /// <summary>
        /// The <see cref="T:Region"/> to return.
        /// </summary>
        /// <remarks>
        /// This property has been made redundant by changes to Ubisoft mechanics since (around) season 17.
        /// This is left for legacy seasons, which remain region-specific
        /// </remarks>
        [QueryParameter("region_id", EnumHandlingMode.String)]
        public Region Region { get; set; }

        [QueryParameter("board_id")]
        private string BoardId => Board switch
        {
            BoardType.Ranked => "pvp_ranked",
            BoardType.Casual => "pvp_casual",

            _ => throw new ArgumentOutOfRangeException()
        };

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        protected override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
