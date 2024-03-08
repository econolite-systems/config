// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Messaging.Sink;
using Econolite.Ode.Config.Messaging.Source;
using Econolite.Ode.Messaging;
using Econolite.Ode.Messaging.Elements;
using Econolite.Ode.Messaging.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Econolite.Ode.Config.Messaging.Extensions
{
    public static class Defined
    {
        public static string ToDefaultTenantChannel(this string channelBase, Guid tenantId) =>
            $"{channelBase}.{tenantId}";

        public static (Action<SourceOptions<ConfigResponseBase>> ResponseBase, Action<DeviceManagerConfigResponseSourceOptions> SourceOptions) ToDmConfigOptionDefaults(this IConfiguration configuration, int deviceManagerId, Guid tenantId) =>
            (_ => _.ConsumerGroupSuffix = deviceManagerId.ToString(), _ => _.DefaultChannel = configuration[Consts.CONFIG_RESPONSE_TOPIC_BASE].ToDefaultTenantChannel(tenantId));

        public static IServiceCollection AddDmConfig(this IServiceCollection services, (Action<SourceOptions<ConfigResponseBase>> ResponseBase, Action<DeviceManagerConfigResponseSourceOptions> SourceOptions) actionOptions) => services
            .AddMessaging()

            // request sink and di
            .Configure<MessageFactoryOptions<ConfigRequest>>(_ =>
            {
                _.FuncBuildPayloadElement = _ => new BaseJsonPayload<ConfigRequest>(_);
            })
            .AddTransient<IMessageFactory<ConfigRequest>, MessageFactory<ConfigRequest>>()
            .AddTransient<ISink<ConfigRequest>, Sink<ConfigRequest>>()
            // config request sink
            .AddTransient<IDeviceManagerConfigRequestSink, DeviceManagerConfigRequestSink>()

            // response source and di
            .Configure<SourceOptions<ConfigResponseBase>>(_ => actionOptions.ResponseBase?.Invoke(_))
            .Configure<DeviceManagerConfigResponseSourceOptions>(_ => actionOptions.SourceOptions?.Invoke(_))
            // payload specialists
            .AddTransient<ProtobufPayloadSpecialist<ConfigResponseBase>>()
            .AddTransient<JsonPayloadSpecialist<ConfigResponseBase>>()
            // combined payload specialist
            .AddTransient<IPayloadSpecialist<ConfigResponseBase>, CombinedPayloadSpecialist<ConfigResponseBase>>()
            .AddTransient<IConsumeResultFactory<ConfigResponseBase>, ConsumeResultFactory<ConfigResponseBase>>()
            .AddTransient<ISource<ConfigResponseBase>, Source<ConfigResponseBase>>()
            // response source
            .AddTransient<IDeviceManagerConfigResponseSource, DeviceManagerConfigResponseSource>();

        public static Action<DeviceManagerConfigRequestSourceOptions> ToRemoteConfigOptionDefaults(this IConfiguration configuration) => _ => _.DefaultChannel = configuration[Consts.CONFIG_REQUEST_TOPIC];
        public static IServiceCollection AddRemoteConfig(this IServiceCollection services, Action<DeviceManagerConfigRequestSourceOptions> actionDeviceManagerConfigRequestSourceOptions) => services
            .AddMessaging()
            // legacy sink messaging
            .Configure<MessageFactoryOptions<ConfigResponseBase>>(_ =>
            {
                _.FuncBuildPayloadElement = _ => new BaseJsonPayload<ConfigResponseBase>(_);
            })
            .AddTransient<IMessageFactory<ConfigResponseBase>, MessageFactory<ConfigResponseBase>>()
            .AddTransient<ISink<ConfigResponseBase>, Sink<ConfigResponseBase>>()
            // proto sink messaging
            .Configure<MessageFactoryOptions<proto.Configuration>>(_ =>
            {
                _.FuncBuildPayloadElement = _ => new BaseProtobufPayload<proto.Configuration>(_);
            })
            .AddTransient<IMessageFactory<proto.Configuration>, MessageFactory<proto.Configuration>>()
            .AddTransient<ISink<proto.Configuration>, Sink<proto.Configuration>>()

            // Response sink
            .AddTransient<IDeviceManagerConfigResponseSink, DeviceManagerConfigResponseSink>()

            .Configure<DeviceManagerConfigRequestSourceOptions>(_ => actionDeviceManagerConfigRequestSourceOptions?.Invoke(_))
            .AddTransient<IPayloadSpecialist<ConfigRequest>, JsonPayloadSpecialist<ConfigRequest>>()
            .AddTransient<IConsumeResultFactory<ConfigRequest>, ConsumeResultFactory<ConfigRequest>>()
            .AddTransient<ISource<ConfigRequest>, Source<ConfigRequest>>()

            .AddTransient<IDeviceManagerConfigRequestSource, DeviceManagerConfigRequestSource>();
    }
}
