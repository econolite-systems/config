// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Common.Extensions;
using Econolite.Ode.Config.Messaging.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProduceConfigTopic;

await Host.CreateDefaultBuilder(args)
    .AddODELogging()
    .ConfigureServices((builderContext, serviceCollection) =>
    {
        serviceCollection
            .AddRemoteConfig(builderContext.Configuration.ToRemoteConfigOptionDefaults())
            .AddHostedService<SendDmConfig>()
            ;
    })
    .Build()
    .StartAsync();
