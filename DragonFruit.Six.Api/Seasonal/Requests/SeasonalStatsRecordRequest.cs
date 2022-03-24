// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Legacy.Requests;
using DragonFruit.Six.Api.Modern.Utils;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Seasonal.Requests
{
    public sealed class SeasonalStatsRecordRequest : PlatformSpecificRequest
    {
        public override string Path => $"{Platform.SandboxUrl()}/r6karma/player_skill_records";

        /// <summary>
        /// Creates a seasonal stats request for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        public SeasonalStatsRecordRequest(IEnumerable<UbisoftAccount> accounts, BoardType boards = BoardType.Ranked, IEnumerable<int> seasons = null, Region regions = Region.EMEA | Region.NCSA | Region.APAC)
            : base(accounts)
        {
            Boards = boards;
            Regions = regions;

            Seasons = seasons ?? (-1).Yield();
        }

        /// <summary>
        /// The leaderboard to return stats for
        /// </summary>
        public BoardType Boards { get; set; }

        /// <summary>
        /// The season number (where <c>-1</c> is the current season)
        /// </summary>
        [QueryParameter("season_ids", CollectionConversionMode.Concatenated)]
        public IEnumerable<int> Seasons { get; set; }

        /// <summary>
        /// The <see cref="T:Region"/>s to return.
        /// </summary>
        /// <remarks>
        /// This property has been made redundant by changes to Ubisoft mechanics since (around) season 17.
        /// This is left for legacy seasons, which remain region-specific
        /// </remarks>
        [QueryParameter("region_ids", EnumHandlingMode.StringLower)]
        public Region Regions { get; set; }

        [QueryParameter("board_ids", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> BoardIds => Enum.GetValues(typeof(BoardType))
                                                    .Cast<BoardType>()
                                                    .Where(x => Boards.HasFlagFast(x))
                                                    .Select(x => typeof(BoardType).GetField(x.ToString()).GetCustomAttribute<EnumMemberAttribute>()?.Value);

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        protected override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
