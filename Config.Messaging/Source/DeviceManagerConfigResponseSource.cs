// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Messaging.Extensions;
using Econolite.Ode.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Source
{
    public class DeviceManagerConfigResponseSource : IDeviceManagerConfigResponseSource
    {
        private readonly ISource<ConfigResponseBase> _source;
        private readonly ILogger _logger;
        private readonly DeviceManagerConfigResponseSourceOptions _options;

        public DeviceManagerConfigResponseSource(ISource<ConfigResponseBase> source, IOptions<DeviceManagerConfigResponseSourceOptions> options, ILoggerFactory loggerFactory)
        {
            _options = options?.Value ?? new();
            _source = source;
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _logger.LogInformation("Listening to channel {@}", _options.DefaultChannel);
        }

        public Task ConsumeOnAsync(int myId, Func<(Guid TenantId, ConfigResponse ConfigResponse), Task> consumeFunc, CancellationToken cancellationToken) =>
            _source.ConsumeOnAsync(_options.DefaultChannel, async (consumed) =>
            {
                ConfigResponseBase config = consumed.Type switch
                {
                    "Configuration" => Build(consumed.ToObject<proto.Configuration>()),
                    "ConfigResponse" => Build(consumed.ToObject<JsonNode>()),
                    _ => null
                };
                if ((config?.DeviceManagerId?? int.MinValue) == myId)
                {
                    await consumeFunc((consumed.TenantId, config.ToConfigResponse()));
                }
            }, cancellationToken);

        private static proto.ConfigRequestProto Build(proto.Configuration configuration) => new proto.ConfigRequestProto
        {
            Configuration= configuration,
            DeviceManagerId = configuration.DeviceManagerId
        };

        private static ConfigResponse Build(JsonNode node) => new ConfigResponse
        {
            Channels = node.ExtractChannels(),
            Devices = node.ExtractDevices(),
            DeviceManagerId = node.ExtractDMId(),
        };
    }
}
