// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using DragonFruit.Common.Storage.Web;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Helpers
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class d6WebRequest
    {
        private static string _appName = "Dragon6 API";

        public static string AppName
        {
            get => _appName;
            set => _appName = value;
        }

        public static HttpClient GetDragon6Client() => WebServices.GetClient(AppName);

        /// <summary>
        /// Memory-Aware method to stream a JSON string to specified Type (T) using the Ubisoft Client
        /// </summary>
        public static T GetWebObject<T>(string uri, string token)
        {
            using var client = GetUbisoftClient(token);
            return WebServices.StreamObject<T>(uri, client);
        }

        /// <summary>
        /// Memory-Aware method to stream a JSON string to specified Type (T)
        /// </summary>
        public static T GetWebObject<T>(string uri)
        {
            using var client = GetDragon6Client();
            return WebServices.StreamObject<T>(uri, client);
        }

        /// <summary>
        /// Memory-Aware method to stream a JSON string to a JObject using the Ubisoft Client
        /// </summary>
        public static JObject GetWebObject(string uri, string token)
        {
            using var client = GetUbisoftClient(token);
            return WebServices.StreamObject(uri, client);
        }

        /// <summary>
        /// Memory-Aware method to stream a JSON string to a JObject
        /// </summary>
        public static JObject GetWebObject(string uri)
        {
            using var client = GetDragon6Client();
            return WebServices.StreamObject(uri, client);
        }

        /// <summary>
        /// sets up a new HttpClient with the token preset token
        /// </summary>
        public static HttpClient GetUbisoftClient(string token)
        {
            var client = GetDragon6Client();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            return client;
        }

        public static string FormStatsUrl(AccountInfo info, string query) => FormStatsUrl(info.Platform, new[] { info.Guid }, query);

        public static string FormStatsUrl(Platforms platform, IEnumerable<string> profiles, string query) =>
            $"{Endpoints.Stats[platform]}?populations={string.Join(',', profiles)}&statistics={query}";
    }
}
