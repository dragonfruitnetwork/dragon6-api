﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dragon6.API
{
    public class AccountInfo
    {
        /// <summary>
        /// The Player's Username (Formatted)
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// URL to Player's Avatar
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Platform the user is on
        /// </summary>
        public References.Platforms Platform { get; set; }
        /// <summary>
        /// User's GUID - used to get stats
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// Get the Account info from Player's name
        /// </summary>
        /// <param name="name">The User's name</param>
        /// <param name="platform">The Platform the user is located on</param>
        /// <param name="token">Valid Token from </param>
        /// <returns></returns>
        public static async Task<AccountInfo> GetFromName(string name, References.Platforms platform,string token)
        {
            var client = new HttpClient();
            var uri = "https://public-ubiservices.ubi.com/v2/profiles?platformType=";

            if (platform == References.Platforms.PC) uri += "uplay";
            if (platform == References.Platforms.PSN) uri += "psn";
            if (platform == References.Platforms.XB1) uri += "xbl";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            var response = await client.GetAsync(uri + "&nameOnPlatform=" + name);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            return await Alignments.AlignAccount(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Get the player's name from GUID (PC ONLY)
        /// </summary>
        /// <param name="GUID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AccountInfo> ReverseID_PC(string GUID,string token)
        {
            var client = new HttpClient();
            var uri = "https://public-ubiservices.ubi.com/v2/profiles?platformType=uplay";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            var content = await client.GetAsync(uri + "&idOnPlatform=" + GUID);
            if (content.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            var response = await Task.Run(async() => JObject.Parse(await content.Content.ReadAsStringAsync()));

            return new AccountInfo
            {
                PlayerName = response["profiles"][0]["nameOnPlatform"].ToString(),
                GUID = GUID,
                Image =
                    $"https://ubisoft-avatars.akamaized.net/{GUID}/default_146_146.png?appId=39baebad-39e5-4552-8c25-2c9b919064e2",
                Platform = References.Platforms.PC
            };
        }


    }
}