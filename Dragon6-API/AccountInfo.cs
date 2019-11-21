// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading.Tasks;
using Dragon6.API.Helpers;
using Dragon6.API.Verification;

namespace Dragon6.API
{
    public class AccountInfo
    {
        /// <summary>
        ///     The Player's Username (Formatted)
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        ///     URL to Player's Avatar
        /// </summary>
        public string Image => $"https://ubisoft-avatars.akamaized.net/{Guid}/default_256_256.png";

        /// <summary>
        ///     User Platform
        /// </summary>
        public References.Platforms Platform { get; set; }

        /// <summary>
        ///     User's GUID - used to get stats
        /// </summary>
        public string Guid { get; set; }

        public Verification.Verification AccountStatus => Server.GetUser(Guid);

        /// <summary>
        ///     Get the Account info from Player's name
        /// </summary>
        /// <param name="name">The User's name</param>
        /// <param name="platform">The Platform the user is located on</param>
        /// <param name="token">Valid Token from </param>
        /// <returns></returns>
        public static async Task<AccountInfo> GetFromName(string name, References.Platforms platform, string token)
        {
            var uri = $"{Endpoints.UplayIdServer}?platformType=";

            uri += platform switch
            {
                References.Platforms.PSN => "psn",
                References.Platforms.XB1 => "xbl",
                _ => "uplay"
            };

            return await Task.Run(() =>
                d6WebRequest.GetWebJObject($"{uri}&nameOnPlatform={name}", token).AlignAccount());
        }

        /// <summary>
        ///     Get the player's name from GUID (PC ONLY)
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AccountInfo> ReverseID_PC(string guid, string token)
        {
            var response = await Task.Run(() =>
                d6WebRequest.GetWebJObject($"{Endpoints.UplayIdServer}?platformType=uplay&idOnPlatform={guid}", token));

            return new AccountInfo
            {
                PlayerName = response["profiles"][0]["nameOnPlatform"].ToString(),
                Guid = guid,
                Platform = References.Platforms.PC
            };
        }
    }
}