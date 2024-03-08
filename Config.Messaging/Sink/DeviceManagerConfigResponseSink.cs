// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Sink
{
    public class DeviceManagerConfigResponseSink : IDeviceManagerConfigResponseSink
    {
        private readonly ISink<ConfigResponseBase> _sinkConfigResponseBase;
        private readonly string _topic;
        private readonly ILogger _logger;
        private readonly ISink<proto.Configuration> _sinkConfiguration;

        public DeviceManagerConfigResponseSink(ISink<ConfigResponseBase> sinkConfigResponseBase, ISink<proto.Configuration> sinkConfiguration, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _sinkConfiguration = sinkConfiguration;
            _sinkConfigResponseBase = sinkConfigResponseBase;
            _topic = configuration[Consts.CONFIG_RESPONSE_TOPIC_BASE];
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _logger.LogInformation("Base channel {@}", _topic);
        }

        public Task SinkAsync(Guid tenantId, ConfigResponseBase configResponse, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sending configuration to {@Dm}", new { TenantId = tenantId, configResponse.DeviceManagerId });
            var topic = $"{_topic}.{tenantId}";
            return configResponse switch
            {
                proto.ConfigRequestProto proto => _sinkConfiguration.SinkAsync((topic, tenantId), tenantId, proto.Configuration, cancellationToken),
                _ => _sinkConfigResponseBase.SinkAsync((topic, tenantId), tenantId, configResponse, cancellationToken),
            };
        }
    }
}
