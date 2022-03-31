// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Utils;
using JetBrains.Annotations;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public abstract class ModernStatsRequest : UbiApiRequest
    {
        private const string DateTimeFormat = "yyyyMMdd";
        private const int DefaultStartWindow = 14;

        private PlaylistType? _playlist;
        private OperatorType? _operatorType;
        private DateTimeOffset? _startDate, _endDate;

        public override string Path => $"https://r6s-stats.ubisoft.com/v1/{RequestCategory}/{RequestType}/{Account.ProfileId}";

        protected ModernStatsRequest(UbisoftAccount account)
        {
            Account = account ?? throw new NullReferenceException();
        }

        /// <summary>
        /// The category the request fits in (i.e. current, seasonal, narrative, etc.)
        /// </summary>
        protected virtual string RequestCategory => "current";

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
        public UbisoftAccount Account { get; }

        /// <summary>
        /// The <see cref="PlaylistType"/> to get stats for (as a bitwise flag)
        /// </summary>
        public PlaylistType Playlist
        {
            get => _playlist ??= PlaylistType.Ranked | PlaylistType.Casual | PlaylistType.Unranked;
            set => _playlist = value;
        }

        /// <summary>
        /// Option to filter stats based on whether they were accumulated during an attack or defense round.
        /// </summary>
        public virtual OperatorType OperatorType
        {
            get => _operatorType ??= OperatorType.Independent;
            set => _operatorType = value;
        }

        /// <summary>
        /// The start date for the stats
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The date provided was more than 120 days ago</exception>
        public virtual DateTimeOffset StartDate
        {
            get => _startDate ??= DateTimeOffset.UtcNow.AddDays(-DefaultStartWindow);
            set
            {
                if (DateTimeOffset.UtcNow.Date.AddDays(-120) > value.Date)
                {
                    throw new ArgumentOutOfRangeException(nameof(StartDate), "Date provided was more than 120 days ago. Stats are only held for upto 120 days before being removed");
                }

                _startDate = value;
            }
        }

        /// <summary>
        /// The end date for the stats
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The date provided is in the future</exception>
        public virtual DateTimeOffset EndDate
        {
            get => _endDate ??= DateTimeOffset.UtcNow;
            set
            {
                if (DateTimeOffset.UtcNow.Date > value.Date)
                {
                    throw new ArgumentOutOfRangeException(nameof(EndDate), "Date provided was in the future");
                }

                _endDate = value;
            }
        }

        [UsedImplicitly]
        [QueryParameter("platform")]
        protected string PlatformName => Account.Platform.ModernName();

        [UsedImplicitly]
        [QueryParameter("gameMode")]
        protected string PlaylistNames => Playlist.Expand();

        [UsedImplicitly]
        [QueryParameter("startDate")]
        protected virtual string FormattedStartDate => StartDate.UtcDateTime.ToString(DateTimeFormat);

        [UsedImplicitly]
        [QueryParameter("endDate")]
        protected virtual string FormattedEndDate => EndDate.UtcDateTime.ToString(DateTimeFormat);

        [UsedImplicitly]
        [QueryParameter("teamRole")]
        protected virtual string OperatorTypeNames => OperatorType.Expand();
    }
}
