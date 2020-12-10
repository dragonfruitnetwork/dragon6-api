// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Data.Requests.Base
{
    public abstract class ModernStatsRequest : UbiApiRequest
    {
        private const string DateTimeFormat = "yyyyMMdd";

        private DateTimeOffset? _startDate;
        private DateTimeOffset? _endDate;

        public override string Path => $"https://r6s-stats.ubisoft.com/v1/current/{RequestType}/{Account.Identifiers.Profile}";

        protected ModernStatsRequest(AccountInfo account)
        {
            Account = account;
        }

        /// <summary>
        /// The type of request (general, operators, weapons, etc.)
        /// </summary>
        /// <remarks>
        /// This is the string included in the uri
        /// </remarks>
        protected abstract string RequestType { get; }

        /// <summary>
        /// The account to get stats for
        /// </summary>
        public AccountInfo Account { get; }

        /// <summary>
        /// The <see cref="PlaylistType"/> to get stats for (as a bitwise flag)
        /// </summary>
        public PlaylistType Playlist { get; set; } = PlaylistType.All;

        /// <summary>
        /// Option to filter stats based on whether they were accumulated during an attack or defense round.
        /// </summary>
        public OperatorType OperatorType { get; set; } = OperatorType.Independent;

        /// <summary>
        /// The start date for the stats
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The date provided was more than 120 days ago</exception>
        public DateTimeOffset StartDate
        {
            get => _startDate ??= DateTimeOffset.Now.AddDays(-7);
            set
            {
                if (DateTimeOffset.UtcNow.AddDays(-120) > value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Date provided was more than 120 days ago. Stats are only held for upto ~6 months before being removed");
                }

                _startDate = value;
            }
        }

        /// <summary>
        /// The end date for the stats
        /// </summary>
        // todo what happens if this is in the future
        public DateTimeOffset EndDate
        {
            get => _endDate ??= DateTimeOffset.Now;
            set => _endDate = value;
        }

        [QueryParameter("platform")]
        protected Platform Platform => Account.Platform;

        [QueryParameter("gameMode")]
        protected string PlaylistNames => Playlist.Expand();

        [QueryParameter("startDate")]
        protected string FormattedStartDate => StartDate.UtcDateTime.ToString(DateTimeFormat);

        [QueryParameter("endDate")]
        protected string FormattedEndDate => EndDate.UtcDateTime.ToString(DateTimeFormat);

        [QueryParameter("teamRole")]
        protected string OperatorTypeNames => OperatorType.HasFlag(OperatorType.Independent)
            // independent = all
            ? (OperatorType.Attacker | OperatorType.Defender).Expand()
            // here we remove the independent flag then expand
            : (OperatorType & ~OperatorType.Independent).Expand();
    }
}
