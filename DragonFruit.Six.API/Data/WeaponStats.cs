// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Data
{
    public class WeaponStats
    {
        public string Guid { get; set; }

        public string ClassName { get; set; }

        public byte ClassID { get; set; }

        public uint Kills { get; set; }

        public uint Headshots { get; set; }

        public uint ShotsFired { get; set; }

        public uint ShotsLanded { get; set; }
    }
}
