// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Entities
{
    public class ServerStatusReport
    {
        [JsonProperty("AppID ")] // the space is intentional
        public string AppId { get; set; }

        [JsonProperty("ImpactedFeatures")]
        public IEnumerable<string> AffectedServices { get; set; }

        [JsonProperty("Status")]
        private string StatusString { get; set; }

        [JsonProperty("Maintenance")]
        private bool? Maintenance { get; set; }

        [JsonIgnore]
        public ServerStatus Status { get; set; }

        [JsonIgnore]
        public Platform Platform { get; set; }

        [OnDeserialized]
        internal void ProcessData(StreamingContext context)
        {
            Platform = UbisoftIdentifiers.GameIds[AppId];
            Status = Maintenance == true
                ? ServerStatus.Maintenance
                : (ServerStatus)Enum.Parse(typeof(ServerStatus), StatusString, true);
        }
    }
}
