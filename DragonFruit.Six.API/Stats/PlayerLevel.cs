// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Stats
{
    public class PlayerLevel
    {
        /// <summary>
        /// The GUID of the user
        /// </summary>
        [JsonProperty("profile")]
        public string Guid { get; set; }

        [JsonProperty("xp")]
        public uint XP { get; set; }

        [JsonProperty("lootbox_probability")]
        public uint AlphaChances { get; set; }

        [JsonProperty("level")]
        public uint Level { get; set; }

        public static async Task<PlayerLevel> GetLevel(AccountInfo account, string token) => (await GetLevel(new[] { account }, token).ConfigureAwait(false)).First();

        public static async Task<IEnumerable<PlayerLevel>> GetLevel(IEnumerable<AccountInfo> accounts, string token)
        {
            var results = new List<PlayerLevel>();

            await foreach (var result in GetLevelAsync(accounts, token))
                results.Add(result);

            return results;
        }

        public static async IAsyncEnumerable<PlayerLevel> GetLevelAsync(IEnumerable<AccountInfo> accounts, string token)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var rawData = await Task.Run(() => d6WebRequest.GetWebObject($"{Endpoints.ProfileInfo[group.Key]}?profile_ids={string.Join(',', group.Select(a => a.Guid))}", token));

                foreach (var element in JArray.FromObject(rawData["player_profiles"]))
                {
                    var result = element.ToObject<PlayerLevel>();
                    result.Guid = (string)element["profile_id"];
                    yield return result;
                }
            }
        }
    }
}
