// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Strings;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class ClassicStatsRequest : ClassicStatsRequestBase
    {
        /// <summary>
        /// Initialises a request for all the stats in <see cref="ClassicStats"/> for the provided <see cref="AccountInfo"/>
        /// </summary>
        public ClassicStatsRequest(AccountInfo account)
            : base(account)
        {
        }

        /// <summary>
        /// Requests all the stats in <see cref="ClassicStats"/> for the provided array of <see cref="AccountInfo"/>s
        /// </summary>
        public ClassicStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            ClassicCasual.Deaths,
            ClassicCasual.Kills,
            ClassicCasual.Losses,
            ClassicCasual.MatchesPlayed,
            ClassicCasual.Wins,
            ClassicCasual.Time,

            ClassicRanked.Deaths,
            ClassicRanked.Kills,
            ClassicRanked.Losses,
            ClassicRanked.MatchesPlayed,
            ClassicRanked.Wins,
            ClassicRanked.Time,

            ClassicTraining.Deaths,
            ClassicTraining.Kills,
            ClassicTraining.Losses,
            ClassicTraining.MatchesPlayed,
            ClassicTraining.Wins,
            ClassicTraining.Time,

            Classic.Deaths,
            Classic.Kills,
            Classic.Losses,
            Classic.MatchesPlayed,
            Classic.Wins,
            Classic.Time,

            Classic.BlindKills,
            Classic.Knives,
            Classic.Penetrations,
            Classic.Assists,
            Classic.Headshots,

            Classic.Suicides,
            Classic.Revives,
            Classic.Downs,
            Classic.DownAssists,

            Classic.Barricades,
            Classic.Reinforcements,
            Classic.GadgetsDestroyed,
            Classic.Experience,

            // see comment with the string as to why this is disabled
            // Classic.DistanceTravelled,
            Classic.BulletFired,
            Classic.BulletHit,

            ClassicModes.Bomb.Highscore,
            ClassicModes.Bomb.Losses,
            ClassicModes.Bomb.MatchesPlayed,
            ClassicModes.Bomb.Time,
            ClassicModes.Bomb.Wins,

            ClassicModes.Hostage.Highscore,
            ClassicModes.Hostage.Losses,
            ClassicModes.Hostage.MatchesPlayed,
            ClassicModes.Hostage.Time,
            ClassicModes.Hostage.Wins,
            ClassicModes.Hostage.Rescues,
            ClassicModes.Hostage.Defenses,

            ClassicModes.Secure.Highscore,
            ClassicModes.Secure.Losses,
            ClassicModes.Secure.MatchesPlayed,
            ClassicModes.Secure.Time,
            ClassicModes.Secure.Wins,
            ClassicModes.Secure.Aggressions,
            ClassicModes.Secure.Defenses,
            ClassicModes.Secure.Captures
        };
    }
}
