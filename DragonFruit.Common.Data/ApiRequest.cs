// DragonFruit.Common Copyright 2020 DragonFruit Network
// Licensed under the MIT License. Please refer to the LICENSE file at the root of this project for details

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Common.Data
{
    public abstract class ApiRequest
    {
        public abstract string Path { get; }

        public virtual Methods Method => Methods.Get;

        public virtual bool RequireAuth => false;

        public virtual string AcceptedContent => string.Empty;

        public string Url => Path + Query;

        public FormUrlEncodedContent FormContent => new FormUrlEncodedContent(GetParameter<FormParameter>());

        public string Query
        {
            get
            {
                var queries = GetParameter<QueryParameter>();
                return !queries.Any() ? string.Empty : "?" + string.Join("&", queries.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetParameter<T>() where T : IProperty
        {
            var properties = GetType().GetProperties().Where(x => x.CustomAttributes.Any());
            foreach (var property in properties)
            {
                if (!(Attribute.GetCustomAttribute(property, typeof(T)) is T parameter))
                    continue;

                var value = property.GetValue(this, null);
                if (value != null)
                    yield return new KeyValuePair<string, string>(parameter.Name, value.ToString());
            }
        }
    }
}