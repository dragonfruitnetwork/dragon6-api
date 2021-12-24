// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Runtime.Serialization;
using DragonFruit.Six.Api.Accounts.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Services.Status
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class UbisoftServerStatus
    {
        [JsonProperty("AppID ")] // the space is intentional
        public string AppId { get; set; }

        [JsonProperty("ImpactedFeatures")]
        public string[] AffectedServices { get; set; }

        [JsonProperty("Status")]
        private string StatusString { get; set; }

        [JsonProperty("Maintenance")]
        private bool? Maintenance { get; set; }

        public Platform? Platform { get; set; }
        public ServerStatus Status { get; set; }

        [OnDeserialized]
        internal void ProcessData(StreamingContext context)
        {
            Platform = UbisoftIdentifiers.GameIds.TryGetValue(AppId, out var platform) ? platform : null;
            Status = Maintenance == true ? ServerStatus.Maintenance : (ServerStatus)Enum.Parse(typeof(ServerStatus), StatusString, true);
        }
    }
}
