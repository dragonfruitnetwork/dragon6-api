using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core.API.Interface
{
    public class TokenStruct
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }

        public static async Task<TokenStruct> GetToken()
        {
            //get the token from firebase
            var cacheToken = (await Accounts.Dragon6DB.Document("token").GetSnapshotAsync()).ToDictionary();
            try
            {
                var token = (string)cacheToken["ticket"];
                var expiry = DateTime.Parse((string)cacheToken["expiration"]);

                if (expiry > DateTime.Now)
                    return new TokenStruct()
                    {
                        Token = token,
                        Expiry = expiry
                    };
                else
                    throw new Exception();

            }
            catch
            {
                using (var client = new HttpClient())
                {
                    HttpContent content = new StringContent("", Encoding.UTF8);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add("Authorization",
                        $"Basic {Accounts.UbisoftAccount}"); 
                    client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");
                    var response =
                        await client.PostAsync("https://uplayconnect.ubi.com/ubiservices/v2/profiles/sessions",
                            content);
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        throw new UnauthorizedAccessException();

                    var values =
                        JsonConvert.DeserializeObject<Dictionary<string, string>>(
                            await response.Content.ReadAsStringAsync());
                    values["expiration"] = DateTime.Parse(values["expiration"]).Subtract(new TimeSpan(0, 20, 0)).ToString();

                    await Accounts.Dragon6DB.Document("token").SetAsync(values);

                    return new TokenStruct()
                    {
                        Token = values["ticket"],
                        Expiry = DateTime.Parse(values["expiration"])
                    };
                }
            }
        }
    }
}
