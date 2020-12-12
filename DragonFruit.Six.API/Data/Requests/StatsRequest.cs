// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Strings;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class StatsRequest : BasicStatsRequest
    {
        /// <summary>
        /// Initialises a request for all the stats in <see cref="Stats"/> for the provided <see cref="AccountInfo"/>
        /// </summary>
        public StatsRequest(AccountInfo account)
            : base(account)
        {
        }

        /// <summary>
        /// Requests all the stats in <see cref="Stats"/> for the provided array of <see cref="AccountInfo"/>s
        /// </summary>
        public StatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            Casual.Deaths,
            Casual.Kills,
            Casual.Losses,
            Casual.MatchesPlayed,
            Casual.Wins,
            Casual.Time,

            Ranked.Deaths,
            Ranked.Kills,
            Ranked.Losses,
            Ranked.MatchesPlayed,
            Ranked.Wins,
            Ranked.Time,

            Training.Deaths,
            Training.Kills,
            Training.Losses,
            Training.MatchesPlayed,
            Training.Wins,
            Training.Time,

            General.Deaths,
            General.Kills,
            General.Losses,
            General.MatchesPlayed,
            General.Wins,
            General.Time,

            General.BlindKills,
            General.Knives,
            General.Penetrations,
            General.Assists,
            General.Headshots,

            General.Suicides,
            General.Revives,
            General.Downs,
            General.DownAssists,

            General.Barricades,
            General.Reinforcements,
            General.GadgetsDestroyed,
            General.Experience,

            // see comment with the string as to why this is disabled
            // General.DistanceTravelled,
            General.BulletFired,
            General.BulletHit,

            Modes.Bomb.Highscore,
            Modes.Bomb.Losses,
            Modes.Bomb.MatchesPlayed,
            Modes.Bomb.Time,
            Modes.Bomb.Wins,

            Modes.Hostage.Highscore,
            Modes.Hostage.Losses,
            Modes.Hostage.MatchesPlayed,
            Modes.Hostage.Time,
            Modes.Hostage.Wins,
            Modes.Hostage.Rescues,
            Modes.Hostage.Defenses,

            Modes.Secure.Highscore,
            Modes.Secure.Losses,
            Modes.Secure.MatchesPlayed,
            Modes.Secure.Time,
            Modes.Secure.Wins,
            Modes.Secure.Aggressions,
            Modes.Secure.Defenses,
            Modes.Secure.Captures
        };
    }
}
