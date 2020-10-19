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

        public string Guid { get; set; }

        public WeaponType Class { get; set; }

        public uint TimesChosen { get; set; }

        public uint Kills { get; set; }

        public uint Deaths { get; set; }

        public uint Headshots { get; set; }

        public uint Downs { get; set; }

        public uint DownAssists { get; set; }

        public uint ShotsFired { get; set; }

        public uint ShotsLanded { get; set; }

        public float Accuracy => _accuracy ??= RatioUtils.RatioOf(ShotsLanded, ShotsFired);
        public float Efficiency => _efficiency ??= RatioUtils.RatioOf(Kills, ShotsFired);
        public float HeadshotRatio => _headshotRatio ??= RatioUtils.RatioOf(Headshots, ShotsLanded);
        public float Power => _power ??= RatioUtils.RatioOf(Kills, ShotsLanded);
    }
}
