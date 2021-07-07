// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Strings.Stats
{
    [DefaultStats(typeof(WeaponStatsRequest))]
    public static class Weapon
    {
        public static string Picked => "weapontypepvp_chosen";
        public static string Kills => "weapontypepvp_kills";
        public static string Deaths => "weapontypepvp_death";
        public static string Headshots => "weapontypepvp_headshot";
        public static string Downs => "weapontypepvp_dbno";
        public static string DownAssists => "weapontypepvp_dbnoassists";
        public static string ShotsFired => "weapontypepvp_bulletfired";
        public static string ShotsHit => "weapontypepvp_bullethit";
    }

    [DefaultStats(typeof(WeaponTrainingStatsRequest))]
    public static class WeaponTraining
    {
        public static string Picked => "weapontypepve_chosen";
        public static string Kills => "weapontypepve_kills";
        public static string Deaths => "weapontypepve_death";
        public static string Headshots => "weapontypepve_headshot";
        public static string Downs => "weapontypepve_dbno";
        public static string DownAssists => "weapontypepve_dbnoassists";
        public static string ShotsFired => "weapontypepve_bulletfired";
        public static string ShotsHit => "weapontypepve_bullethit";
    }
}
