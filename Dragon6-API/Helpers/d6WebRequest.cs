using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dragon6.API.Helpers
{
    public static class d6WebRequest
    {
        private static readonly JsonSerializer JsonSerializer = JsonSerializer.Create(JSONConverter.JsonParser);

        public static HttpClient GetDragon6Client()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Dragon6");

            return client;
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to specified Type (T) using the Ubisoft Client
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static T GetWebObject<T>(string uri, string token)
        {
            using (HttpClient client = GetUbisoftClient(token))
            {
                return StreamGenericObject<T>(uri, client);
            }
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to specified Type (T)
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static T GetWebObject<T>(string uri)
        {
            using (HttpClient client = GetDragon6Client())
            {
                return StreamGenericObject<T>(uri, client);
            }
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to a JObject using the Ubisoft Client
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns>JObject to be used to extract data</returns>
        public static JObject GetWebJObject(string uri, string token)
        {
            using (HttpClient client = GetUbisoftClient(token))
            {
                return StreamJObject(uri, client);
            }
        }

        /// <summary>
        ///     Memory-Aware method to stream a JSON string to a JObject
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <returns>JObject to be used to extract data</returns>
        public static JObject GetWebJObject(string uri)
        {
            using (HttpClient client = GetDragon6Client())
            {
                return StreamJObject(uri, client);
            }
        }

        /// <summary>
        ///     internal method for streaming an object
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        internal static JObject StreamJObject(string uri, HttpClient client)
        {
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return JObject.Load(reader);
            }
        }

        /// <summary>
        ///     internal method for streaming an object
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        internal static T StreamGenericObject<T>(string uri, HttpClient client)
        {
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return JsonSerializer.Deserialize<T>(reader);
            }
        }

        /// <summary>
        ///     sets up a new HttpClient with the token preset token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static HttpClient GetUbisoftClient(string token)
        {
            var client = new HttpClient();
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
            return $"{Endpoints.Stats[info.Platform]}?populations={info.GUID}&statistics={query}";
        }

        public static string FormAccountInfoUrl(References.Platforms platform, string playerIds)
        {
            return $"{Endpoints.ProfileInfo[platform]}?profile_ids={playerIds}";
        }
    }
}