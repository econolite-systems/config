// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Messaging.Source;
using Econolite.Ode.Config.Messaging.Sink;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsumeConfigTopic
{
    public class GetDmConfig : IHostedService
    {
        private readonly IDeviceManagerConfigResponseSource _deviceManagerConfigResponseSource;
        private readonly IDeviceManagerConfigRequestSink _deviceManagerConfigRequestSink;
        private readonly Guid _tenantId;
        private ILogger _logger;
        private int _dmId;

        public GetDmConfig(IDeviceManagerConfigResponseSource deviceManagerConfigResponseSource, IDeviceManagerConfigRequestSink deviceManagerConfigRequestSink, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _deviceManagerConfigResponseSource = deviceManagerConfigResponseSource;
            _deviceManagerConfigRequestSink = deviceManagerConfigRequestSink;
            _tenantId = Guid.Parse(configuration["Tenant:Id"] ?? "What were you thinking");
            _dmId = int.Parse(configuration["Tenant:DeviceManagerId"] ?? "1");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sent request {@}", (_tenantId, _dmId));
            await _deviceManagerConfigRequestSink.SinkAsync(_tenantId, _dmId);
            while (! cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await _deviceManagerConfigResponseSource.ConsumeOnAsync(_dmId, (response) =>
                    {
                        _logger.LogInformation("Config: {@}", response.ConfigResponse);
                        return Task.CompletedTask;
                    }, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception in the main processing loop");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
