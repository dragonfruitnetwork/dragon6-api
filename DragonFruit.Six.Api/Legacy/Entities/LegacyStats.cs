// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Diagnostics;
using DragonFruit.Six.Api.Containers;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    [DebuggerDisplay("Id = {ProfileId}")]
    public class LegacyStats
    {
        [JsonProperty("profile")]
        internal string ProfileId { get; set; }

        [JsonProperty("overall")]
        public LegacyPlaylistStats Overall { get; set; }

        [JsonProperty("casual")]
        public LegacyPlaylistStats Casual { get; set; }

        [JsonProperty("ranked")]
        public LegacyPlaylistStats Ranked { get; set; }

        [JsonProperty("training")]
        public LegacyPlaylistStats Training { get; set; }

        [JsonProperty("bomb")]
        public LegacyModeStats Bomb { get; set; }

        [JsonProperty("hostage")]
        public LegacyModeStats Hostage { get; set; }

        [JsonProperty("secure")]
        public LegacyModeStats Secure { get; set; }

        /// <summary>
        /// Total barricades built
        /// </summary>
        [JsonProperty("barricades")]
        public uint Barricades { get; set; }

        /// <summary>
        /// Total reinforcements deployed
        /// </summary>
        [JsonProperty("reinforcements")]
        public uint Reinforcements { get; set; }

        /// <summary>
        /// Total gadgets destroyed
        /// </summary>
        [JsonProperty("gadgets_destroyed")]
        public uint GadgetsDestroyed { get; set; }

        /// <summary>
        /// Number of opponents downed
        /// </summary>
        [JsonProperty("downs")]
        public uint Downs { get; set; }

        /// <summary>
        /// Number of teammates revived from a downed state
        /// </summary>
        [JsonProperty("revives")]
        public uint Revives { get; set; }

        /// <summary>
        /// Number of times the player has killed themself (C4, jumping off a building, etc.)
        /// </summary>
        [JsonProperty("suicides")]
        public uint Suicides { get; set; }

        /// <summary>
        /// Total headshot kills
        /// </summary>
        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        /// <summary>
        /// Total wallbangs
        /// </summary>
        [JsonProperty("penetrations")]
        public uint Penetrations { get; set; }

        /// <summary>
        /// Total kills when unable to see (i.e. a flashbang or an angry blitz)
        /// </summary>
        [JsonProperty("blind_kills")]
        public uint BlindKills { get; set; }

        /// <summary>
        /// Total knife kills
        /// </summary>
        [JsonProperty("melee")]
        public uint Knifes { get; set; }

        /// <summary>
        /// Total kill assists
        /// </summary>
        [JsonProperty("assists")]
        public uint Assists { get; set; }

        /// <summary>
        /// Total down assists (assisting in downing an opponent)
        /// </summary>
        // todo convert to ulong
        [JsonProperty("down_assists")]
        public uint DownAssists { get; set; }

        /// <summary>
        /// Total shots fired
        /// </summary>
        [JsonProperty("shots_fired")]
        public ulong ShotsFired { get; set; }

        /// <summary>
        /// Total shots connected
        /// </summary>
        [JsonProperty("shots_connected")]
        public ulong ShotsConnected { get; set; }

        /// <summary>
        /// Total points gained from all modes
        /// </summary>
        [JsonProperty("experience")]
        public ulong Experience { get; set; }
    }
}
