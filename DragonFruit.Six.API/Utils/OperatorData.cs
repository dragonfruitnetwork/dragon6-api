// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Requests;

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
        public static IEnumerable<ClassicOperatorStats> FromFile(string location)
        {
            return FileServices.ReadFile<IEnumerable<ClassicOperatorStats>>(location);
        }

        /// <summary>
        /// Gets the <see cref="IEnumerable{T}"/> needed to use the <see cref="GetOperatorStats"/> extensions
        /// </summary>
        /// <param name="client">The <see cref="ApiClient"/> to use</param>
        public static IEnumerable<ClassicOperatorStats> GetOperatorInfo(this ApiClient client)
        {
            var request = new ClassicOperatorDataRequest(null);
            return client.Perform<IEnumerable<ClassicOperatorStats>>(request);
        }
    }
}
