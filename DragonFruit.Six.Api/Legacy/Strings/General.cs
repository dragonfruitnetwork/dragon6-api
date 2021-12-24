// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy.Utils;

namespace DragonFruit.Six.Api.Legacy.Strings
{
    [DefaultStats(LegacyStatTypes.General)]
    internal static class General
    {
        public const string Kills = "generalpvp_kills";
        public const string Deaths = "generalpvp_death";

        public const string Wins = "generalpvp_matchwon";
        public const string Losses = "generalpvp_matchlost";

        public const string Time = "generalpvp_timeplayed";
        public const string MatchesPlayed = "generalpvp_matchplayed";

        public const string Barricades = "generalpvp_barricadedeployed";
        public const string Reinforcements = "generalpvp_reinforcementdeploy";
        public const string GadgetsDestroyed = "generalpvp_gadgetdestroy";

        public const string Downs = "generalpvp_dbno";
        public const string Revives = "generalpvp_revive";

        public const string Headshots = "generalpvp_headshot";
        public const string Knives = "generalpvp_meleekills";
        public const string Penetrations = "generalpvp_penetrationkills";
        public const string BlindKills = "generalpvp_blindkills";

        public const string Assists = "generalpvp_killassists";
        public const string DownAssists = "generalpvp_dbnoassists";
        public const string Suicides = "generalpvp_suicide";

        public const string BulletFired = "generalpvp_bulletfired";
        public const string BulletHit = "generalpvp_bullethit";

        public const string Experience = "generalpvp_totalxp";
    }
}
