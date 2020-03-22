// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Globalization;
using DragonFruit.Common.Data.Serializers;
using System.Net.Http;
using System.Text;

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

        public override StringContent Serialize<T>(T input) => new StringContent(string.Empty, Encoding.UTF8, "application/json");
    }
}
