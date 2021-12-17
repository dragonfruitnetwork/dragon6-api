// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DragonFruit.Six.Api.Modern.Utils
{
    /// <summary>
    /// A <see cref="JsonConverter"/> for traversing through multiple properties separated by a full stop
    /// </summary>
    /// <remarks>
    /// Taken from https://automationrhapsody.com/partial-json-deserialize-jsonpath-json-net/
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
                var jsonPropertyAttr = prop.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();

                if (jsonPropertyAttr == null)
                {
                    continue;
                }

                var token = jObject.SelectToken(jsonPropertyAttr.PropertyName);

                if (token == null || token.Type == JTokenType.Null)
                {
                    continue;
                }

                var jsonConverterAttr = prop.GetCustomAttributes(true).OfType<JsonConverterAttribute>().FirstOrDefault();
                object value;

                if (jsonConverterAttr == null)
                {
                    serializer.Converters.Clear();
                    value = token.ToObject(prop.PropertyType, serializer);
                }
                else
                {
                    value = JsonConvert.DeserializeObject(token.ToString(), prop.PropertyType, (JsonConverter)Activator.CreateInstance(jsonConverterAttr.ConverterType));
                }

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

        public override bool CanConvert(Type objectType) => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}
