// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Data
{
    public class WeaponStats
    {
        private float? _power;
        private float? _headshotRatio;
        private float? _efficiency;
        private float? _accuracy;

        /// <summary>
        /// Profile Id
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// <see cref="WeaponType"/> the stats relate to
        /// </summary>
        public WeaponType Class { get; set; }

        /// <summary>
        /// Total times this class has been picked by the user
        /// </summary>
        public uint TimesChosen { get; set; }

        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public uint Headshots { get; set; }

        public uint Downs { get; set; }
        public uint DownAssists { get; set; }

        public uint ShotsFired { get; set; }
        public uint ShotsLanded { get; set; }

        /// <summary>
        /// Accuracy ratio consisting of <see cref="ShotsLanded"/> to <see cref="ShotsFired"/>
        /// </summary>
        public float Accuracy => _accuracy ??= RatioUtils.RatioOf(ShotsLanded, ShotsFired);

        /// <summary>
        /// Efficiency ratio consisting of <see cref="Kills"/> to <see cref="ShotsFired"/>
        /// </summary>
        public float Efficiency => _efficiency ??= RatioUtils.RatioOf(Kills, ShotsFired);

        /// <summary>
        /// Headshot ratio consisting of <see cref="Headshots"/> to <see cref="ShotsLanded"/>
        /// </summary>
        public float HeadshotRatio => _headshotRatio ??= RatioUtils.RatioOf(Headshots, ShotsLanded);

        /// <summary>
        /// Power ratio consisting of <see cref="Kills"/> to <see cref="ShotsLanded"/>
        /// </summary>
        public float Power => _power ??= RatioUtils.RatioOf(Kills, ShotsLanded);
    }
}
