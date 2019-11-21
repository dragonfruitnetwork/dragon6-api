// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Net.Http;
using System.Net.Http.Headers;
using DragonFruit.Common.Storage.Web;
using Newtonsoft.Json.Linq;

namespace Dragon6.API.Helpers
{
    public static class d6WebRequest
    {
        public static string AppName = "Dragon6 API";

        public static HttpClient GetDragon6Client() => WebServices.GetClient(AppName);

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to specified Type (T) using the Ubisoft Client
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static T GetWebObject<T>(string uri, string token)
        {
            using var client = GetUbisoftClient(token);
            return WebServices.StreamObject<T>(uri, client);
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to specified Type (T)
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static T GetWebObject<T>(string uri)
        {
            using var client = GetDragon6Client();
            return WebServices.StreamObject<T>(uri, client);
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to a JObject using the Ubisoft Client
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns>JObject to be used to extract data</returns>
        public static JObject GetWebJObject(string uri, string token)
        {
            using var client = GetUbisoftClient(token);
            return WebServices.StreamJObject(uri, client);
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to a JObject
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns>JObject to be used to extract data</returns>
        public static JObject GetWebJObject(string uri)
        {
            using var client = GetDragon6Client();
            return WebServices.StreamJObject(uri, client);
        }


        /// <summary>
        ///     sets up a new HttpClient with the token preset token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static HttpClient GetUbisoftClient(string token)
        {
            var client = GetDragon6Client();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            return client;
        }

        /// <summary>
        ///     generates the endpoint to access stats for the account's platform
        /// </summary>
        /// <param name="info"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string FormStatsUrl(AccountInfo info, string query)
        {
            return $"{Endpoints.Stats[info.Platform]}?populations={info.Guid}&statistics={query}";
        }

        public static string FormAccountInfoUrl(References.Platforms platform, string playerIds)
        {
            return $"{Endpoints.ProfileInfo[platform]}?profile_ids={playerIds}";
        }
    }
}