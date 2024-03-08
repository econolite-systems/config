// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Cache.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Cache
{
    public class SPaTSignalIdCache : ISPaTSignalIdCache
    {
        private object _lock = new object();
        private long _cacheRefreshedAtTicks = 0;
        private readonly IDistributedCache _distributedCache;
        private readonly SPaTSignalIdCacheOptions _options;
        Dictionary<int, Guid>? _cachedMappings = null;

        public SPaTSignalIdCache(IDistributedCache distributedCache, IOptions<SPaTSignalIdCacheOptions> options)
        {
            _distributedCache = distributedCache;
            _options = options.Value;
        }

        public async Task<Guid> GetSignalIdAsync(Guid tenantId, int signalId, CancellationToken cancellationToken = default)
        {
            Guid result = Guid.Empty;
            var refreshedate = DateTime.FromBinary(Interlocked.Read(ref _cacheRefreshedAtTicks));
            var cacheage = DateTime.Now - refreshedate;
            if (cacheage > _options.RefreshFromCache)
            {
                await RefreshCache(tenantId, cancellationToken);
            }
            var cachedmappings = Interlocked.CompareExchange(ref _cachedMappings, null, null);
            _ = cachedmappings != null && cachedmappings.TryGetValue(signalId, out result);
            return result;
        }

        public async Task PutSignalMapsAsync(Guid tenantId, Dictionary<int, Guid> signalMapping, CancellationToken cancellationToken = default)
        {
            await _distributedCache.SetStringAsync(tenantId.ToSPaTSignalIdKey(), System.Text.Json.JsonSerializer.Serialize(signalMapping));
        }

        private Task RefreshCache(Guid tenantId, CancellationToken cancellationToken)
        {
            // This function could be called multiple times before the
            // cache is refreshed so this method attempts to only read
            // from the cache if a separate call didn't already refresh
            // the cache.
            lock (_lock)
            {
                var refreshedate = DateTime.FromBinary(Interlocked.Read(ref _cacheRefreshedAtTicks));
                var cacheage = DateTime.Now - refreshedate;
                if (cacheage > _options.RefreshFromCache)
                {
                    var cacheddata = _distributedCache.GetString(tenantId.ToSPaTSignalIdKey());
                    if (cacheddata != null)
                    {
                        var cachedmap = System.Text.Json.JsonSerializer.Deserialize<Dictionary<int, Guid>>(cacheddata);
                        Interlocked.Exchange(ref _cachedMappings, cachedmap);
                        Interlocked.Exchange(ref _cacheRefreshedAtTicks, DateTime.Now.ToBinary());
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
