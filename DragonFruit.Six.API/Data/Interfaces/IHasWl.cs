// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Data.Interfaces
{
    public interface IHasWl
    {
        public uint Wins { get; set; }
        public uint Losses { get; set; }

        public float Wl { get; }
    }
}
