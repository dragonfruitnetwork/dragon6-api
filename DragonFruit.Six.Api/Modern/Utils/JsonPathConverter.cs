// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DragonFruit.Six.Api.Modern.Utils
{
    /// <summary>
    /// A <see cref="JsonConverter"/> for extracting elements based on a JPath expression
    /// </summary>
    /// <remarks>
    /// Portions taken from https://automationrhapsody.com/partial-json-deserialize-jsonpath-json-net/
    /// </remarks>
    internal class JsonPathConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            var targetObj = contract?.DefaultCreator?.Invoke() ?? Activator.CreateInstance(objectType);
            var jObject = JObject.Load(reader);

            foreach (var prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                // allow fetching by path or by jsonproperty if there's no path
                var path = prop.GetCustomAttribute<JsonPathAttribute>(true)?.Path ?? prop.GetCustomAttribute<JsonPropertyAttribute>(true)?.PropertyName;

                if (path == null)
                {
                    continue;
                }

                var token = jObject.SelectToken(path);

                if (token == null || token.Type == JTokenType.Null)
                {
                    continue;
                }

                var jsonConverterAttr = prop.GetCustomAttribute<JsonConverterAttribute>(true);
                object value;

                value = jsonConverterAttr == null
                    ? token.ToObject(prop.PropertyType, serializer)
                    : JsonConvert.DeserializeObject(token.ToString(), prop.PropertyType, (JsonConverter)Activator.CreateInstance(jsonConverterAttr.ConverterType));

                prop.SetValue(targetObj, value, null);
            }

            if (contract?.OnDeserializedCallbacks != null)
            {
                foreach (var callback in contract.OnDeserializedCallbacks)
                {
                    callback.Invoke(targetObj, serializer.Context);
                }
            }

            return targetObj;
        }

        public override bool CanConvert(Type objectType) => !objectType.IsInterface && objectType.GetCustomAttribute<JsonPathSerializableAttribute>() is not null;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();
    }
}
