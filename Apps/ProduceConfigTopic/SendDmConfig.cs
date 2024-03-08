// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using Econolite.Ode.Config.Devices;
using Econolite.Ode.Config.Messaging;
using Econolite.Ode.Config.Messaging.Extensions;
using Econolite.Ode.Config.Messaging.proto;
using Econolite.Ode.Config.Messaging.Sink;
using Econolite.Ode.Config.Messaging.Source;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Protocol = Econolite.Ode.Config.Channels.Protocol;
using SignalType = Econolite.Ode.Config.Devices.SignalType;

namespace ProduceConfigTopic
{
    public class SendDmConfig : IHostedService
    {
        private readonly IDeviceManagerConfigRequestSource _deviceManagerConfigRequestSource;
        private readonly IDeviceManagerConfigResponseSink _deviceManagerConfigResponseSink;
        private readonly ILogger _logger;
        private readonly Guid _tenantId;

        public SendDmConfig(IDeviceManagerConfigRequestSource deviceManagerConfigRequestSource, IDeviceManagerConfigResponseSink deviceManagerConfigResponseSink, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _deviceManagerConfigRequestSource = deviceManagerConfigRequestSource;
            _deviceManagerConfigResponseSink = deviceManagerConfigResponseSink;
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _tenantId = Guid.Parse(configuration["Tenant:Id"] ?? "What were you thinking");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        await _deviceManagerConfigRequestSource.ConsumeOn(async (consumed) =>
                        {
                            _logger.LogInformation("Received request for {@}", (consumed.TenantId, consumed.DeviceManagerId));
                            var response = GetResponse(consumed.DeviceManagerId);
                            await _deviceManagerConfigResponseSink.SinkAsync(consumed.TenantId, response, cancellationToken);
                            if (consumed.RequestVersion >= 2)
                            {
                                await _deviceManagerConfigResponseSink.SinkAsync(consumed.TenantId, response.ToProtobuf(), cancellationToken);
                            }
                            _logger.LogInformation("Sent response");
                        }, cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error");
                        throw;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Stopped");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Fatal error");
                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        private ConfigRequestProto GetProto(int dmId)
        {
            var result = new ConfigRequestProto
            {
                DeviceManagerId = dmId,
                Configuration = new Configuration
                {
                    DeviceManagerId = dmId,
                }
            };


            return result;
        }

        private ConfigResponse GetResponse(int dmId) => 
            new ConfigResponse
            {
                DeviceManagerId = dmId,
                Channels = new BaseChannelConfig[]
                {
                    new UdpConfig()
                    {
                        BroadcastIPAddress = "",
                        ByteRxTimeout = 500,
                        CommRequestTimeout = 500,
                        FailedPollRate = 3,
                        Id = 1,
                        InnerByteDelay = 0,
                        InnerChannelDelay = false,
                        MaxExpectedPacketSize = 540,
                        InnerDeviceDelay = 0,
                        Name = "Don't let them aboard",
                        PollErrorThreshold = 3,
                        PollRetries = 0,
                        PrimaryPollRate = 1000,
                        PriorityPollRate = 1000,
                        Protocol = Protocol.NTCIP,
                        Retries = 3,
                        SecondaryPollRate = 30000,
                        SourceIp = "0.0.0.0",
                        SourcePort = 0,
                        TertiaryPollRate = 0,
                        TimeFormat = DeviceTimeFormat.TimeUTC,
                    },
                },
                Devices = new BaseDeviceConfig[]
                {
                    new SignalConfig(externalTag: "", deviceId:
                    Guid.NewGuid(), deviceSubType: (byte)SignalType.Eos,
                    commMode:CommMode.Online, channelType: ChannelType.Udp, protocol: Protocol.NTCIP,
                    deviceIp: "127.0.0.1", devicePort: 0, deviceDropAddress: null, deviceRetries: 1, devicePollRetries: 0,
                    primaryPollRate: 1000, secondaryPollRate: 30000, tertiaryPollRate: 0, priorityPollRate: 1000,
                    failedPollRate: 10000, channelId: 1, pollErrorThreshold: 1, commRequestTimeout: 500,
                    deviceTimeFormat: DeviceTimeFormat.TimeUTC, broadcastIpAddress: "0.0.0.0",
                    snmpCommunityName: "administrator", ftpUsername: "econolite",
                    ftpPassword: "ecpi2ecpi", sshHostKey: "", sshPort: 22, maxVbsPerPdu: 6, backupPreventPeriod: TimeSpan.FromMinutes(value: 1),
                    dynObjDefIds: new[] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, dynamicDetectorReferences: new byte[0], msgPhases: 0, msgOverlaps: 0, ssgPhases: 0, ssgOverlaps: 0,
                    isHighResCtrlEnabled: false, detectors: new Dictionary<byte, Detector>(),
                    samplingDetectors: new Dictionary<byte, Detector>(), volumeOccupancyPeriod: 60000, filteredCommWeightingFactor: 30,
                    filteredCommMarginal: 70, filteredCommBad: 30,
                    discoverDynamicObjects: false, allowTimeDrift: TimeSpan.FromSeconds(5), detectorFaultPolling: false),
                },
            };
    }
}
