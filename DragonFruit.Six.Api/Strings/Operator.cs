// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Strings
{
    public static class Operator
    {
        public static string Wins => "operatorpvp_roundwon";
        public static string WinsTraining => "operatorpve_roundwon";
        public static string Losses => "operatorpvp_roundlost";
        public static string LossesTraining => "operatorpve_roundlost";

        public static string Kills => "operatorpvp_kills";
        public static string KillsTraining => "operatorpve_kills";
        public static string Deaths => "operatorpvp_death";
        public static string DeathsTraining => "operatorpve_death";

        public static string Downs => "operatorpvp_headshot";
        public static string DownsTraining => "operatorpve_headshot";
        public static string Headshots => "operatorpvp_dbno";
        public static string HeadshotsTraining => "operatorpve_dbno";

        public static string Rounds => "operatorpvp_roundplayed";
        public static string RoundsTraining => "operatorpve_roundplayed";
        public static string Time => "operatorpvp_timeplayed";
        public static string TimeTraining => "operatorpve_timeplayed";
        public static string Experience => "operatorpvp_totalxp";
        public static string ExperienceTraining => "operatorpve_totalxp";
    }
}
