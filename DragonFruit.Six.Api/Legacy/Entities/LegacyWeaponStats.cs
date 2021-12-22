// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Diagnostics;
using DragonFruit.Six.Api.Enums;
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
        /// <see cref="WeaponType"/> the stats relate to
        /// </summary>
        [JsonProperty("class")]
        public WeaponType Class { get; set; }

        /// <summary>
        /// Total times this class has been picked by the user
        /// </summary>
        [JsonProperty("picks")]
        public uint TimesChosen { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("downs")]
        public uint Downs { get; set; }

        [JsonProperty("down_assists")]
        public uint DownAssists { get; set; }

        [JsonProperty("shots_fired")]
        public uint ShotsFired { get; set; }

        [JsonProperty("shots_landed")]
        public uint ShotsLanded { get; set; }

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
}
