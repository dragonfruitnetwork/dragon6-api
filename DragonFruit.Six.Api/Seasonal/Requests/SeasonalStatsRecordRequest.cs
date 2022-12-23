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
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Exceptions;
using DragonFruit.Six.Api.Modern.Utils;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Seasonal.Requests
{
    public class SeasonalStatsRecordRequest : UbiApiRequest
    {
        internal const int CrossPlatformProgressionId = 28;

        public override string Path => $"{Platform.SandboxUrl()}/r6karma/player_skill_records";

        /// <summary>
        /// Creates a seasonal stats request for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        public SeasonalStatsRecordRequest(IEnumerable<UbisoftAccount> accounts, IEnumerable<int> seasons = null, BoardType boards = BoardType.All)
        {
            Accounts = accounts as IReadOnlyCollection<UbisoftAccount> ?? accounts.ToList();
            Seasons = seasons ?? (-1).Yield();
            Boards = boards;

            // due to how platform switching now works, the user can request both old and new stats at the same time.
            // for simplicity, the request will only switch to crossplay if either -1 or seasons 28+ is requested.
            Platform = Seasons.Any(x => x is >= CrossPlatformProgressionId or -1) ? Platform.CrossPlatform : Accounts.First().Platform;

            // because old seasons use platform-specific spaces, perform platform checks
            if (Platform != Platform.CrossPlatform && Accounts.Any(x => x.Platform != Platform))
            {
                throw new AccountPlatformException(Accounts);
            }
        }

        public IReadOnlyCollection<UbisoftAccount> Accounts { get; }

        /// <summary>
        /// The platform to target stats lookups on.
        /// This may not be the same as the <see cref="Accounts"/>' platforms due to the way seasonal stats are stored
        /// </summary>
        public Platform Platform { get; }

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
        public Region Regions { get; set; } = Region.EMEA;

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> AccountIds => Accounts.Select(x => x.ProfileId);

        [QueryParameter("board_ids", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> BoardIds => Enum.GetValues(typeof(BoardType))
                                                    .Cast<BoardType>()
                                                    .Where(x => Boards.HasFlagFast(x) && x != BoardType.All)
                                                    .Select(x => typeof(BoardType).GetField(x.ToString()).GetCustomAttribute<EnumMemberAttribute>()?.Value);
    }
}
