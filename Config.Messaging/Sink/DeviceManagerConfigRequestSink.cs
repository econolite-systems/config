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
    public class DeviceManagerConfigRequestSink : IDeviceManagerConfigRequestSink
    {
        private readonly ISink<ConfigRequest> _sink;
        private readonly IConfiguration _configuration;
        private readonly string _topic;
        private readonly ILogger _logger;

        public DeviceManagerConfigRequestSink(ISink<ConfigRequest> sink, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _sink = sink;
            _configuration = configuration;
            _topic = _configuration[Consts.CONFIG_REQUEST_TOPIC];
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _logger.LogInformation("Using channel {@}", _topic);
        }

        public Task SinkAsync(Guid tenantId, int deviceManagerId)
        {
            _logger.LogInformation("Sending configuration request DM id: {@DmId}", deviceManagerId);
            return _sink.SinkAsync((_topic, tenantId), tenantId, new ConfigRequest
            {
                DeviceManagerId = deviceManagerId,
                RequestVersion = Consts.VERSION_TWO,
            }, CancellationToken.None);
        }
    }
}
