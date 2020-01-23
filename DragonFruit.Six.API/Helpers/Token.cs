// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DragonFruit.Common.Storage.Shared;
using DragonFruit.Common.Storage.Web;
using DragonFruit.Six.API.Processing;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Helpers
{
    public class Token
    {
        [JsonProperty("clientIp")]
        public string ClientIP { get; set; }

        [JsonProperty("clientIpCountry")]
        public string ClientCountry { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("expriation")]
        public DateTime Expiry { get; set; }

        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("spaceId")]
        public string SpaceId { get; set; }

        [JsonProperty("sessionKey")]
        public string SessionKey { get; set; }

        [JsonProperty("account")]
        public AccountInfo Account { get; set; }

        private static string _credentials;

        /// <summary>
        /// Get the token using the credentials set using <see cref="SetCredentials(string, string)"/>
        /// </summary>
        /// <returns>Token to be used to access stats</returns>
        public static async Task<Token> GetToken()
        {
            using var client = d6WebRequest.GetDragon6Client();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {_credentials}"); //change this to the current user's credentials
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            HttpContent content = new StringContent(string.Empty, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Task.Run(() => WebServices.PostData(Endpoints.TokenServer, content, client));

            var token = response.ToObject<Token>();
            token.Account = new AccountInfo
            {
                Guid = response.GetString(Accounts.ProfileIdentifier),
                Platform = PlatformParser.PlatformEnumFor(response.GetString(Accounts.PlatformIdentifier, "uplay")),
                PlayerName = response.GetString(Accounts.Name),
            };

            return token;
        }

        /// <summary>
        /// Sets the Credentials to get a token using <see cref="GetToken"/>
        /// </summary>
        /// <param name="username">The username to be used (usually an email)</param>
        /// <param name="password">The account's password</param>
        public static void SetCredentials(string username, string password) => _credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
    }
}
