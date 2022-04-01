// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Modern.Containers
{
    public struct RatioBackedStat
    {
        internal RatioBackedStat(uint total, float ratio)
        {
            Ratio = ratio;
            Value = (int)(total * Ratio);
        }

        /// <summary>
        /// Converted value formed of the total applicable values multiplied by the <see cref="Ratio"/>
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The ratio of valid items relative to the total
        /// </summary>
        public float Ratio { get; }
    }
}
