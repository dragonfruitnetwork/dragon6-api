// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Data.Requests;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Utils;
using DragonFruit.Six.Api.Seasonal.Requests;
using JetBrains.Annotations;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public abstract class ModernStatsRequest : UbiApiRequest, IRequestExecutingCallback
    {
        private const string DateTimeFormat = "yyyyMMdd";
        private const int DefaultStartWindow = 14;

        private static readonly DateTimeOffset CrossPlatformStartDate = new(2022, 12, 6, 0, 0, 0, TimeSpan.Zero);

        private PlaylistType? _playlist;
        private OperatorType? _operatorType;
        private DateTimeOffset? _startDate, _endDate;

        protected readonly IList<KeyValuePair<string, string>> Queries;

        public override string Path => $"https://prod.datadev.ubisoft.com/v1/users/{Account.UbisoftId}/playerstats";

        protected override UbisoftService? RequiredTokenSource => UbisoftService.NewStatsSite;
        protected override IEnumerable<KeyValuePair<string, string>> AdditionalQueries => Queries;

        protected ModernStatsRequest(UbisoftAccount account)
        {
            Account = account ?? throw new NullReferenceException();

            Queries = new List<KeyValuePair<string, string>>(1);
        }

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

        /// <summary>
        /// List of seasons to return stats for. Provides an alternative timespan compared to start-end dates.
        /// </summary>
        [QueryParameter("seasons", CollectionConversionMode.Concatenated)]
        public virtual IEnumerable<ModernSeason> Seasons { get; set; }

        /// <summary>
        /// Optional <see cref="PlatformGroup"/> to override when getting cross-progression metrics
        /// </summary>
        public PlatformGroup? PlatformGroup { get; set; }

        /// <summary>
        /// The type of request (general, operators, weapons, etc.)
        /// </summary>
        /// <remarks>
        /// This is the string included in the uri
        /// </remarks>
        [UsedImplicitly]
        [QueryParameter("aggregation")]
        protected abstract string RequestType { get; }

        /// <summary>
        /// The category the request fits in (i.e. current, seasonal, narrative, etc.)
        /// </summary>
        [UsedImplicitly]
        [QueryParameter("view")]
        protected virtual string RequestCategory => "current";

        [UsedImplicitly]
        [QueryParameter("spaceId")]
        protected string GameSpaceId => Account.Platform.GameSpaceId();

        [UsedImplicitly]
        [QueryParameter("gameMode")]
        protected string PlaylistNames => Playlist.Expand();

        [CanBeNull]
        [UsedImplicitly]
        [QueryParameter("startDate")]
        protected virtual string FormattedStartDate => Seasons == null ? StartDate.UtcDateTime.ToString(DateTimeFormat) : null;

        [CanBeNull]
        [UsedImplicitly]
        [QueryParameter("endDate")]
        protected virtual string FormattedEndDate => Seasons == null ? EndDate.UtcDateTime.ToString(DateTimeFormat) : null;

        [UsedImplicitly]
        [QueryParameter("teamRole")]
        protected virtual string OperatorTypeNames => OperatorType.Expand();

        void IRequestExecutingCallback.OnRequestExecuting(ApiClient client)
        {
            bool useCrossPlayQueries;

            if (Seasons?.Any() != true)
            {
                useCrossPlayQueries = EndDate > CrossPlatformStartDate;
            }
            else
            {
                // check seasons to make sure old and new seasons aren't mixed in
                if (Seasons.All(x => x.SeasonNumber < SeasonalStatsRecordRequest.CrossPlatformProgressionId))
                {
                    useCrossPlayQueries = false;
                }
                else if (Seasons.All(x => x.SeasonNumber >= SeasonalStatsRecordRequest.CrossPlatformProgressionId))
                {
                    useCrossPlayQueries = true;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Seasons)} combines both cross-platform and individual platform seasons.", nameof(Seasons));
                }
            }

            var platformQuery = useCrossPlayQueries
                ? new KeyValuePair<string, string>("platform", Account.Platform.ModernName())
                : new KeyValuePair<string, string>("platformGroup", (PlatformGroup ?? (Account.Platform == Platform.PC ? Api.Enums.PlatformGroup.PC : Api.Enums.PlatformGroup.Console)).ToString());

            Queries.Clear();
            Queries.Add(platformQuery);
        }
    }
}
