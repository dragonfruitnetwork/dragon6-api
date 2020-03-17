// DragonFruit.Common Copyright 2020 DragonFruit Network
// Licensed under the MIT License. Please refer to the LICENSE file at the root of this project for details

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DragonFruit.Common.Data.Parameters;
using Newtonsoft.Json;

namespace DragonFruit.Common.Data.Serializers
{
    public class ApiJsonSerializer : ISerializer
    {
        public ApiJsonSerializer()
            : this(CultureInfo.InvariantCulture)
        {
        }

        public ApiJsonSerializer(CultureInfo culture)
        {
            Serializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                Culture = culture
            });
        }

        public JsonSerializer Serializer { get; set; }

        public StringContent Serialize<T>(T input) where T : ApiRequest
        {
            var data = new Dictionary<string, object>();
            foreach (var property in GetType().GetProperties())
            {
                if (Attribute.GetCustomAttribute(property, typeof(StringParameter)) is StringParameter parameter)
                    data.Add(parameter.Name, property.GetValue(input, null));
            }

            var builder = new StringBuilder();
            var writer = new StringWriter(builder);

            using (var jsonWriter = new JsonTextWriter(writer))
                Serializer.Serialize(jsonWriter, data);

            return new StringContent(builder.ToString());
        }

        public T Deserialize<T>(Task<Stream> input) where T : class
        {
            using (var sr = new StreamReader(input.Result))
            using (JsonReader reader = new JsonTextReader(sr))
                return Serializer.Deserialize<T>(reader);
        }
    }
}