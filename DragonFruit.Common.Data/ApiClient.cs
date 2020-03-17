// DragonFruit.Common Copyright 2020 DragonFruit Network
// Licensed under the MIT License. Please refer to the LICENSE file at the root of this project for details

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Common.Data.Serializers;

namespace DragonFruit.Common.Data
{
    /// <summary>
    /// <see cref="HttpClient"/>-related data
    /// </summary>
    public class ApiClient
    {
        public ApiClient()
        {
            Serializer = new ApiJsonSerializer();
        }

        public ApiClient(CultureInfo culture)
        {
            Serializer = new ApiJsonSerializer(culture);
        }

        /// <summary>
        /// The User-Agent string sent as a header
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Any additional headers to be sent
        /// </summary>
        public List<KeyValuePair<string, string>> CustomHeaders { get; set; } = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// The Authorization header
        /// </summary>
        public string Authorization { get; set; } = null;

        /// <summary>
        /// Optional <see cref="HttpClient"/> settings sent by the <see cref="HttpClientHandler"/>
        /// </summary>
        public HttpClientHandler Handler { get; set; } = null;

        /// <summary>
        /// Method for getting data
        /// </summary>
        public ISerializer Serializer { get; set; }

        ///Hashes to determine whether we replace the <see cref="HttpClient" />
        private string _lastClientHash = string.Empty;
        public string ClientHash => $"{HashCodeOf(UserAgent)}.{HashCodeOf(CustomHeaders)}.{HashCodeOf(Handler)}.{HashCodeOf(Authorization)}";
        /// end hashes
        
        ///_clients and thread locks
        private bool _clientAdjustmentInProgress;
        private HttpClient _client;

        ///end _clients

        public virtual HttpClient GetClient(ApiRequest requestData)
        {
            while (_clientAdjustmentInProgress)
                Thread.Sleep(200);

            if (!_lastClientHash.Equals(ClientHash))
            {
                _clientAdjustmentInProgress = true;

                //cleanup from old attempts
                _client?.Dispose();
                _client = Handler != null ? new HttpClient(Handler, true) : new HttpClient();
                var hasAuthData = !string.IsNullOrEmpty(Authorization);

                if (requestData.RequireAuth && !hasAuthData)
                    //todo custom exceptions
                    throw new Exception("Authorization data expected, but not found");

                if (hasAuthData)
                    _client.DefaultRequestHeaders.Add("Authorization", Authorization);

                if (!string.IsNullOrEmpty(UserAgent))
                    _client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);

                if (!string.IsNullOrEmpty(requestData.AcceptedContent))
                    _client.DefaultRequestHeaders.Accept.ParseAdd(requestData.AcceptedContent);

                foreach (var header in CustomHeaders)
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);

                _lastClientHash = ClientHash;
                _clientAdjustmentInProgress = false;
            }

            return _client;
        }

        /// <summary>
        /// Perform a web request with an <see cref="ApiRequest"/>
        /// </summary>
        public virtual T Perform<T>(ApiRequest requestData) where T : class
        {
            var client = GetClient(requestData);

            //method specific modes and returns
            switch (requestData.Method)
            {
                case Methods.Get:
                    return Serializer.Deserialize<T>(client.GetStreamAsync(requestData.Url));

                case Methods.PostForm:
                    return Serializer.Deserialize<T>(client.PostAsync(requestData.Url, requestData.FormContent).Result.Content.ReadAsStreamAsync());

                case Methods.PostString:
                    return Serializer.Deserialize<T>(client.PostAsync(requestData.Url, Serializer.Serialize(requestData)).Result.Content.ReadAsStreamAsync());

                case Methods.PutForm:
                    return Serializer.Deserialize<T>(client.PutAsync(requestData.Url, requestData.FormContent).Result.Content.ReadAsStreamAsync());

                case Methods.PutString:
                    return Serializer.Deserialize<T>(client.PutAsync(requestData.Url, Serializer.Serialize(requestData)).Result.Content.ReadAsStreamAsync());

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Perform a web request with an <see cref="ApiRequest"/>
        /// </summary>
        public virtual string PerformString(ApiRequest requestData)
        {
            var client = GetClient(requestData);
            Task<string> requestResponseTask;

            //method specific modes and returns
            switch (requestData.Method)
            {
                case Methods.Get:
                    requestResponseTask = client.GetStringAsync(requestData.Url);
                    break;

                case Methods.PostForm:
                    requestResponseTask =  client.PostAsync(requestData.Url, requestData.FormContent).Result.Content.ReadAsStringAsync();
                    break;

                case Methods.PostString:
                    requestResponseTask =  client.PostAsync(requestData.Url, Serializer.Serialize(requestData)).Result.Content.ReadAsStringAsync();
                    break;

                case Methods.PutForm:
                    requestResponseTask =  client.PutAsync(requestData.Url, requestData.FormContent).Result.Content.ReadAsStringAsync();
                    break;

                case Methods.PutString:
                    requestResponseTask =  client.PutAsync(requestData.Url, Serializer.Serialize(requestData)).Result.Content.ReadAsStringAsync();
                    break;

                default:
                    throw new NotImplementedException();
            }

            using (requestResponseTask)
            {
                requestResponseTask.Wait();
                return requestResponseTask.Result;
            }
        }

        private static string HashCodeOf(object data) => data == null ? "!" : data.GetHashCode().ToString();
    }
}