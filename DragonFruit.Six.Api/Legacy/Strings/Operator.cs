// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy.Utils;

namespace DragonFruit.Six.Api.Legacy.Strings
{
    [DefaultStats(LegacyStatTypes.Operators)]
    public static class Operator
    {
        public const string Wins = "operatorpvp_roundwon";
        public const string WinsTraining = "operatorpve_roundwon";
        public const string Losses = "operatorpvp_roundlost";

        public const string Kills = "operatorpvp_kills";
        public const string KillsTraining = "operatorpve_kills";
        public const string Deaths = "operatorpvp_death";

        public const string Downs = "operatorpvp_headshot";
        public const string DownsTraining = "operatorpve_headshot";
        public const string Headshots = "operatorpvp_dbno";

        public const string Rounds = "operatorpvp_roundplayed";
        public const string Time = "operatorpvp_timeplayed";
        public const string Experience = "operatorpvp_totalxp";
    }
}
