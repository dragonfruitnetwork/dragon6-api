using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dragon6.API.Helpers
{
    public class JSONConverter
    {
        public static readonly JsonSerializerSettings JsonParser = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            Culture = new CultureInfo("en-US"),
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
        };

        internal readonly JObject Source;

        public JSONConverter(JObject obj)
        {
            Source = obj;
        }

        public JSONConverter(JToken obj)
        {
            Source = (JObject) obj;
        }

        public bool IsValid => Source != null;

        public int GetInt32(string key, int @default = 0)
        {
            return ((int?) GetBase(key)).GetValueOrDefault(@default);
        }

        public long GetInt64(string key, long @default = 0)
        {
            return ((long?) GetBase(key)).GetValueOrDefault(@default);
        }

        public double GetDouble(string key, double @default = 0)
        {
            return ((double?) GetBase(key)).GetValueOrDefault(@default);
        }

        public float GetFloat(string key, float @default = 0)
        {
            return ((float?) GetBase(key)).GetValueOrDefault(@default);
        }

        public bool GetBool(string key, bool @default = false)
        {
            return ((bool?) GetBase(key)).GetValueOrDefault(@default);
        }

        /// <summary>
        ///     gets the value from JSON, returning null in event of issue
        /// </summary>
        private JToken GetBase(string key)
        {
            try
            {
                return Source[key];
            }
            catch
            {
                return null;
            }
        }
    }
}