// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Strings;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class GeneralStatsRequest : BasicStatsRequest
    {
        public GeneralStatsRequest(AccountInfo account)
            : base(account)
        {
        }

        public GeneralStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            GeneralCasual.Deaths,
            GeneralCasual.Kills,
            GeneralCasual.Losses,
            GeneralCasual.MatchesPlayed,
            GeneralCasual.Wins,
            GeneralCasual.Time,

            GeneralRanked.Deaths,
            GeneralRanked.Kills,
            GeneralRanked.Losses,
            GeneralRanked.MatchesPlayed,
            GeneralRanked.Wins,
            GeneralRanked.Time,

            GeneralTraining.Deaths,
            GeneralTraining.Kills,
            GeneralTraining.Losses,
            GeneralTraining.MatchesPlayed,
            GeneralTraining.Wins,
            GeneralTraining.Time,

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

            General.DistanceTravelled,
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
