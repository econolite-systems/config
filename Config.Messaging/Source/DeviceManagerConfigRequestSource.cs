// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Source
{
    public class DeviceManagerConfigRequestSource : IDeviceManagerConfigRequestSource
    {
        private readonly ISource<ConfigRequest> _source;
        private readonly ILogger _logger;
        private readonly DeviceManagerConfigRequestSourceOptions _options;

        public DeviceManagerConfigRequestSource(ISource<ConfigRequest> source, IOptions<DeviceManagerConfigRequestSourceOptions> options, ILoggerFactory loggerFactory)
        {
            _source = source;
            _options = options?.Value ?? new();
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _logger.LogInformation("Listening to channel {@}", _options.DefaultChannel);
        }

        public Task ConsumeOn(Func<(Guid TenantId, int DeviceManagerId, int RequestVersion), Task> consumeFunc, CancellationToken cancellationToken) =>
            _source.ConsumeOnAsync(_options.DefaultChannel, async (consumed) =>
            {
                if (consumed.Type == typeof(ConfigRequest).Name)
                {
                    var request = consumed.ToObject<ConfigRequest>();
                    await consumeFunc((consumed.TenantId, request.DeviceManagerId, request.RequestVersion));
                }
                else
                {
                    _logger.LogDebug("Consumed non ConfigRequest type {@}", consumed);
                }
            }, cancellationToken);
    }
}
