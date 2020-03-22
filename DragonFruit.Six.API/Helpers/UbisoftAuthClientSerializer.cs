// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Globalization;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using System.Net.Http;

namespace DragonFruit.Six.API.Helpers
{
    /// <summary>
    /// Custom Serializer that overrides <see cref="Serialize{T}"/> to post raw content
    /// </summary>
    public class UbisoftAuthClientSerializer : ApiJsonSerializer
    {
        public UbisoftAuthClientSerializer()
            : base(CultureInfo.InvariantCulture)
        {
        }

        public UbisoftAuthClientSerializer(CultureInfo culture)
            : base(culture)
        {
        }

        public new StringContent Serialize<T>(T input) where T : ApiRequest => new StringContent("");
    }
}
