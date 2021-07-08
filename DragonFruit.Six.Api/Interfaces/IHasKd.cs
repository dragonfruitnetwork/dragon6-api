// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Interfaces
{
    /// <summary>
    /// Indicates that the implementing entity has information to provide a K/D ratio
    /// </summary>
    public interface IHasKd
    {
        public uint Kills { get; set; }
        public uint Deaths { get; set; }

        public float Kd { get; }
    }
}
