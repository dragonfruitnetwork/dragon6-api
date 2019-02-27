using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dragon6.API
{
    public class Token
    {
        private static string credentials;

        /// <summary>
        /// Get the token using the credentials set using Token.SetCredentials().
        /// </summary>
        /// <returns>Token to be used to access stats</returns>
        public static async Task<string> GetToken()
        {
            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent("", Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization",
                    $"Basic {credentials}"); //change this to the current user's credentials
                client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");
                var response =
                    await client.PostAsync("https://uplayconnect.ubi.com/ubiservices/v2/profiles/sessions",
                        content);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();

                var values =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(
                        await response.Content.ReadAsStringAsync());
                
                return values["ticket"];
            }
        }

        /// <summary>
        /// Sets the Credentials to get the Token.
        /// </summary>
        /// <param name="username">The username to be used (It's usually the email)</param>
        /// <param name="password">The account's password</param>
        public static void SetCredentials(string username, string password)
        {
            credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        }
    }
}
