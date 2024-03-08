// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Common.Extensions;
using ConsumeConfigTopic;
using Econolite.Ode.Config.Messaging.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .AddODELogging()
    .ConfigureServices((builderContext, serviceCollection) =>
    {
        serviceCollection
            .AddDmConfig(builderContext.Configuration.ToDmConfigOptionDefaults(int.Parse(builderContext.Configuration["Tenant:DeviceManagerId"] ?? "1"), Guid.Parse(builderContext.Configuration["Tenant:Id"] ?? "What were you thinking")))
            .AddHostedService<GetDmConfig>();
    })
    .Build()
    .StartAsync();
