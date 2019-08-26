using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Dragon6.API.Http
{
    public class Preset
    {
        /// <summary>
        /// sets up a new HttpClient with the token already embedded
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static System.Net.Http.HttpClient GetClient(string Token)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + Token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            return client;
        }

        /// <summary>
        /// generates the endpoint to access stats for the account's platform
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Query"></param>
        /// <returns></returns>
        public static string FormStatsURL(AccountInfo Info, string Query) => $"{Http.Endpoints.Stats[Info.Platform]}?populations={Info.GUID}&statistics={Query}";
        public static string FormAccountInfoURL(References.Platforms Platform, string PlayerIDS) => $"{Http.Endpoints.ProfileInfo[Platform]}?profile_ids={PlayerIDS}";

    }
}
