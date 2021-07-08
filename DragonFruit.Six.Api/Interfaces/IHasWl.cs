// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Interfaces
{
    /// <summary>
    /// Indicates that the implementing entity has information to provide a W/L ratio
    /// </summary>
    public interface IHasWl
    {
        public uint Wins { get; set; }
        public uint Losses { get; set; }

        public float Wl { get; }
    }
}
