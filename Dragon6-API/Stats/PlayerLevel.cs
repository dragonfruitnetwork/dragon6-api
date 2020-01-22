using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Stats
{
    public class PlayerLevel
    {
        /// <summary>
        /// The GUID of the user
        /// </summary>
        [JsonProperty("profile_id")]
        public string Guid { get; set; }

        [JsonProperty("xp")]
        public uint XP { get; set; }

        [JsonProperty("lootbox_probability")]
        public uint AlphaChances { get; set; }

        [JsonProperty("level")]
        public uint Level { get; set; }

        public static async Task<IEnumerable<PlayerLevel>> GetLevel(IEnumerable<AccountInfo> accounts, string token)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);
            var results = new List<PlayerLevel>();

            foreach (var group in filteredGroups)
            {
                var rawData = await Task.Run(() => d6WebRequest.GetWebObject($"{Endpoints.ProfileInfo[group.Key]}?profile_ids={string.Join(',', group.Select(a => a.Guid))}", token));

                results.AddRange(rawData["player_profiles"].ToObject<IEnumerable<PlayerLevel>>());
            }

            return results;
        }

        public static async Task<PlayerLevel> GetLevel(AccountInfo account, string token) => (await GetLevel(new[] { account }, token)).First();
    }
}
