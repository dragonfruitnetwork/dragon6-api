﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Common.Data;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Extensions
{
    internal static class PlatformStatsExtensions
    {
        internal static Task<ILookup<string, TReturn>> GetPlatformStatsAsync<TRequest, TReturn>(ApiClient client, IEnumerable<AccountInfo> accounts, CancellationToken token, Func<JObject, ILookup<string, TReturn>> callback, Func<IEnumerable<AccountInfo>, TRequest> requestFactory = null) where TRequest : PlatformSpecificRequest
        {
            requestFactory ??= a => (TRequest)Activator.CreateInstance(typeof(TRequest), a);

            var requests = accounts.GroupBy(x => x.Platform).Select(x => client.PerformAsync<JObject>(requestFactory(x), token));
            return Task.WhenAll(requests).ContinueWith(t => callback.Invoke(t.Result.Aggregate(Merge)), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        internal static ILookup<string, TReturn> GetPlatformStats<TRequest, TReturn>(ApiClient client, IEnumerable<AccountInfo> accounts, CancellationToken token, Func<JObject, ILookup<string, TReturn>> callback, Func<IEnumerable<AccountInfo>, TRequest> requestFactory = null) where TRequest : PlatformSpecificRequest
        {
            requestFactory ??= a => (TRequest)Activator.CreateInstance(typeof(TRequest), a);

            var json = accounts.GroupBy(x => x.Platform).Select(x => client.Perform<JObject>(requestFactory(x), token)).Aggregate(Merge);
            return callback.Invoke(json);
        }

        internal static JObject Merge(JObject a, JObject b)
        {
            a.Merge(b);
            return a;
        }
    }
}