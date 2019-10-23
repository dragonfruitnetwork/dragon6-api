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
        public string Image => $"https://ubisoft-avatars.akamaized.net/{GUID}/default_256_256.png";

        /// <summary>
        ///     Platform the user is on
        /// </summary>
        public References.Platforms Platform { get; set; }

        /// <summary>
        ///     User's GUID - used to get stats
        /// </summary>
        public string GUID { get; set; }

        public Verification.Verification AccountStatus => Server.GetUser(GUID);

        /// <summary>
        ///     Get the Account info from Player's name
        /// </summary>
        /// <param name="name">The User's name</param>
        /// <param name="platform">The Platform the user is located on</param>
        /// <param name="token">Valid Token from </param>
        /// <returns></returns>
        public static async Task<AccountInfo> GetFromName(string name, References.Platforms platform, string token)
        {
            var uri = $"{Endpoints.UplayIDServer}?platformType=";

            switch (platform)
            {
                case References.Platforms.PC:
                    uri += "uplay";
                    break;
                case References.Platforms.PSN:
                    uri += "psn";
                    break;
                case References.Platforms.XB1:
                    uri += "xbl";
                    break;
            }

            return await Task.Run(() =>
                d6WebRequest.GetWebJObject($"{uri}&nameOnPlatform={name}", token).AlignAccount());
        }

        /// <summary>
        ///     Get the player's name from GUID (PC ONLY)
        /// </summary>
        /// <param name="GUID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AccountInfo> ReverseID_PC(string GUID, string token)
        {
            var response = await Task.Run(() =>
                d6WebRequest.GetWebJObject($"{Endpoints.UplayIDServer}?platformType=uplay&idOnPlatform={GUID}", token));

            return new AccountInfo
            {
                PlayerName = response["profiles"][0]["nameOnPlatform"].ToString(),
                GUID = GUID,
                Platform = References.Platforms.PC
            };
        }
    }
}