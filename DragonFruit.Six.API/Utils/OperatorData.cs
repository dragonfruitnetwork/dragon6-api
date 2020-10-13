// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Requests;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Utils
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class OperatorData
    {
        /// <summary>
        /// Loads the operator info datasheet from a local file
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static IEnumerable<OperatorStats> FromFile(string location) => FromArray(FileServices.ReadFile<JArray>(location));

        /// <summary>
        /// Gets the <see cref="IEnumerable{T}"/> needed to use the <see cref="GetOperatorStats"/> extensions
        /// </summary>
        /// <param name="client">The <see cref="ApiClient"/> to use</param>
        public static IEnumerable<OperatorStats> GetOperatorInfo(this ApiClient client)
        {
            var request = new OperatorInfoRequest();
            var response = client.Perform<JArray>(request);
            return FromArray(response);
        }

        /// <summary>
        /// Converts a valid <see cref="JArray"/> to a collection of <see cref="OperatorStats"/>, to be used when requesting operator data
        /// </summary>
        public static IEnumerable<OperatorStats> FromArray(JArray data) =>
            data.Cast<JObject>().Select(element => new OperatorStats
            {
                ImageURL = element.GetString("img"),
                Name = element.GetString("name"),
                Organisation = element.GetString("org"),
                Index = element.GetString("index"),
                Subtitle = element.GetString("sub"),
                Type = (OperatorType)element.GetInt("type"),
                OperatorActionId = element.GetString("actn"),
                Action = element.GetString("phrase"),
                Order = element.GetUShort("ord")
            });
    }
}
