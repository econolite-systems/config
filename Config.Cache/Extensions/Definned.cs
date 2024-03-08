// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Econolite.Ode.Config.Cache.Extensions
{
    public static class Defined
    {
        public static IServiceCollection AddSPaTSignalIdCache(this IServiceCollection services) => services
            .AddTransient<ISPaTSignalIdCache, SPaTSignalIdCache>();
        public static IServiceCollection AddSPaTSignalIdCache(this IServiceCollection services, Action<SPaTSignalIdCacheOptions> options) => services
            .Configure<SPaTSignalIdCacheOptions>(_ => options(_))
            .AddSPaTSignalIdCache();

        public static string ToSPaTSignalIdKey(this Guid tenantId) =>
            $"{tenantId.ToString().ToUpper()}:SPaTSignals";
    }
}
