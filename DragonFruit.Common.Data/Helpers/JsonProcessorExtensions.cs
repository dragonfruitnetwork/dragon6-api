// DragonFruit.Common Copyright 2020 DragonFruit Network
// Licensed under the MIT License. Please refer to the LICENSE file at the root of this project for details

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Common.Data.Helpers
{
    public static class JsonProcessorExtensions
    {
        public static string GetString(this JObject source, string key, string @default = "") =>
            (string) GetBase(source, key) ?? @default;
        
        public static bool GetBool(this JObject source, string key, bool @default = false) =>
            ((bool?) GetBase(source, key)).GetValueOrDefault(@default);


        public static byte GetByte(this JObject source, string key, byte @default = 0) =>
            ((byte?) GetBase(source, key)).GetValueOrDefault(@default);

        public static short GetShort(this JObject source, string key, short @default = 0) =>
            ((short?) GetBase(source, key)).GetValueOrDefault(@default);

        public static int GetInt(this JObject source, string key, int @default = 0) =>
            ((int?) GetBase(source, key)).GetValueOrDefault(@default);

        public static long GetLong(this JObject source, string key, long @default = 0) =>
            ((long?) GetBase(source, key)).GetValueOrDefault(@default);


        public static sbyte GetSByte(this JObject source, string key, sbyte @default = 0) =>
            ((sbyte?) GetBase(source, key)).GetValueOrDefault(@default);

        public static ushort GetUShort(this JObject source, string key, ushort @default = 0) =>
            ((ushort?) GetBase(source, key)).GetValueOrDefault(@default);

        public static uint GetUInt(this JObject source, string key, uint @default = 0) =>
            ((uint?) GetBase(source, key)).GetValueOrDefault(@default);

        public static ulong GetULong(this JObject source, string key, ulong @default = 0) =>
            ((ulong?) GetBase(source, key)).GetValueOrDefault(@default);


        public static double GetDouble(this JObject source, string key, double @default = 0) =>
            ((double?) GetBase(source, key)).GetValueOrDefault(@default);

        public static float GetFloat(this JObject source, string key, float @default = 0) =>
            ((float?) GetBase(source, key)).GetValueOrDefault(@default);

        public static decimal GetDecimal(this JObject source, string key, decimal @default = 0) =>
            ((decimal?) GetBase(source, key)).GetValueOrDefault(@default);


        public static IEnumerable<T> GetArray<T>(this JObject source, string key)
        {
            try
            {
                return (IEnumerable<T>) GetBase(source, key);
            }
            catch
            {
                return new List<T>();
            }
        }

        /// <summary>
        ///     Gets the value as a <see cref="JToken" /> type from <see cref="source" />, returning null in event of issue.
        /// </summary>
        private static JToken GetBase(this JObject source, string key)
        {
            try
            {
                return source[key];
            }
            catch
            {
                return null;
            }
        }
    }
}