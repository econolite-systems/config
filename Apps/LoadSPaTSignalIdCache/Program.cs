// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Common.Extensions;
using Econolite.Ode.Cache.Extensions;
using Econolite.Ode.Config.Cache.Extensions;
using LoadSPaTSignalIdCache;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .AddODELogging()
    .ConfigureServices((builderContext, serviceCollection) =>
    {
        serviceCollection
            .AddCaching(_ => _.ConnectionString = builderContext.Configuration["Redis:Connection"])
            .AddSPaTSignalIdCache(_ => _.RefreshFromCache = TimeSpan.FromSeconds(int.Parse(builderContext.Configuration["Redis:RefreshFromCache"] ?? "300")))
            .AddHostedService<LoadCache>();
    })
    .Build()
    .StartAsync();
