// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.ComponentModel;
using System.Diagnostics;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    [DebuggerDisplay("Profile = {ProfileId}, Weapon = {Class}")]
    public class LegacyWeaponStats
    {
        private float? _kd, _power, _headshotRatio, _efficiency, _accuracy;

        [JsonProperty("profile")]
        internal string ProfileId { get; set; }

        /// <summary>
        /// <see cref="LegacyWeaponType"/> the stats relate to
        /// </summary>
        [JsonProperty("class")]
        public LegacyWeaponType Class { get; set; }

        /// <summary>
        /// Total times this class has been picked by the user
        /// </summary>
        [JsonProperty("picks")]
        public int TimesChosen { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("headshots")]
        public int Headshots { get; set; }

        [JsonProperty("downs")]
        public int Downs { get; set; }

        [JsonProperty("down_assists")]
        public int DownAssists { get; set; }

        [JsonProperty("shots_fired")]
        public long ShotsFired { get; set; }

        [JsonProperty("shots_landed")]
        public long ShotsLanded { get; set; }

        [JsonProperty("kd")]
        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);

        /// <summary>
        /// Accuracy ratio consisting of <see cref="ShotsLanded"/> to <see cref="ShotsFired"/>
        /// </summary>
        [JsonProperty("ar")]
        public float Accuracy => _accuracy ??= RatioUtils.RatioOf(ShotsLanded, ShotsFired);

        /// <summary>
        /// Efficiency ratio consisting of <see cref="Kills"/> to <see cref="ShotsFired"/>
        /// </summary>
        [JsonProperty("er")]
        public float Efficiency => _efficiency ??= RatioUtils.RatioOf(Kills, ShotsFired);

        /// <summary>
        /// Headshot ratio consisting of <see cref="Headshots"/> to <see cref="ShotsLanded"/>
        /// </summary>
        [JsonProperty("hr")]
        public float HeadshotRatio => _headshotRatio ??= RatioUtils.RatioOf(Headshots, ShotsLanded);

        /// <summary>
        /// Power ratio consisting of <see cref="Kills"/> to <see cref="ShotsLanded"/>
        /// </summary>
        [JsonProperty("pr")]
        public float Power => _power ??= RatioUtils.RatioOf(Kills, ShotsLanded);
    }

    /// <summary>
    /// The categories a weapon can fall under
    /// </summary>
    public enum LegacyWeaponType
    {
        [Description("Assault Rifle")]
        AssaultRifle = 1,

        [Description("Submachine Gun")]
        SubmachineGun = 2,

        [Description("Light Machine Gun")]
        LightMachineGun = 3,

        [Description("Marksman Rifle")]
        MarksmanRifle = 4,

        [Description("Pistol")]
        Pistol = 5,

        [Description("Shotgun")]
        Shotgun = 6,

        [Description("Machine Pistol")]
        MachinePistol = 7,

        [Description("Shield")]
        Shield = 8,

        [Description("Launcher")]
        Launcher = 9,
    }
}
