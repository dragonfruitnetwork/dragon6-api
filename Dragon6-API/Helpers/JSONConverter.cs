using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon6.API.Helpers
{
    public class JSONConverter
    {
        public JSONConverter(JObject obj)
        {
            Source = obj;
        }

        internal readonly JObject Source;

        public bool IsValid { get => Source != null; }
        public int GetInt32(string key, int @default = 0) => ((int?)GetBase(key)).GetValueOrDefault(@default);

        public long GetInt64(string key, long @default = 0) => ((long?)GetBase(key)).GetValueOrDefault(@default);

        public double GetDouble(string key, double @default = 0) => ((double?)GetBase(key)).GetValueOrDefault(@default);

        public float GetFloat(string key, float @default = 0) => ((float?)GetBase(key)).GetValueOrDefault(@default);

        public bool GetBool(string key, bool @default = false) => ((bool?)GetBase(key)).GetValueOrDefault(@default);

        /// <summary>
        /// gets the value from JSON, returning null in event of issue
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
