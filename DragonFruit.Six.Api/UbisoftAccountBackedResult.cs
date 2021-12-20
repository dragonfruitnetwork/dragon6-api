// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts.Entities;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class UbisoftAccountBackedResult<T> where T : class
    {
        [JsonProperty("results")]
        private Dictionary<string, T> Data { get; set; }

        public T this[UbisoftAccount account] => this[account.ProfileId];
        public T this[string profileId] => Data.TryGetValue(profileId, out var data) ? data : null;
    }
}
