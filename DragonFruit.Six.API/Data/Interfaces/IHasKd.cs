// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Data.Interfaces
{
    public interface IHasKd
    {
        public uint Kills { get; set; }
        public uint Deaths { get; set; }

        public float Kd { get; }
    }
}
