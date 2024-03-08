// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace LoadSPaTSignalIdCache
{
    public class LoadCache : IHostedService
    {
        private readonly ISPaTSignalIdCache _aISPaTSignalIdCache;
        private readonly Guid _tenantId;

        private readonly Dictionary<int, Guid> _theMap = new Dictionary<int, Guid>
        {
            // AI SPaT 1
            { 14971, new Guid("f2afb35a-c452-4230-815e-5ce1b8b7b2ab") },
            // AI SPaT 2
            { 14936, new Guid("ac866812-2ac3-462c-9890-3ac125df24e6") },
            // AI SPaT 3
            { 14798, new Guid("f28a01f5-2d4f-4411-a8ed-70ae0398308c") },
            // AI SPaT 4
            { 14965, new Guid("e6f3096b-aeb8-4198-b2b0-52894db093c2") },
        };

        public LoadCache(ISPaTSignalIdCache aISPaTSignalIdCache, IConfiguration configuration)
        {
            _aISPaTSignalIdCache = aISPaTSignalIdCache;
            _tenantId = Guid.Parse(configuration["Tenant:Id"] ?? "Die");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _aISPaTSignalIdCache.PutSignalMapsAsync(_tenantId, _theMap);
        }

        public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
