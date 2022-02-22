// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Seasonal.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SeasonInfo
    {
        [Key]
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("name")]
        [JsonProperty("operation")]
        public string Name { get; set; }

        [Column("colour")]
        [JsonProperty("accent")]
        public string Colour { get; set; }

        [Column("year")]
        [JsonProperty("year")]
        public int Year { get; set; }

        [Column("season")]
        [JsonProperty("season")]
        public int Season { get; set; }
    }
}
