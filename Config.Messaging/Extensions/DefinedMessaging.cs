// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using Econolite.Ode.Config.Devices;
using System;
using System.Linq;
using System.Text.Json.Nodes;

namespace Econolite.Ode.Config.Messaging.Extensions
{
    public static class DefinedMessaging
    {
        public static proto.ConfigRequestProto ToProtobuf(this ConfigResponse configResponse)
        {
            var result = new proto.ConfigRequestProto
            {
                DeviceManagerId = configResponse.DeviceManagerId,
                Configuration = new proto.Configuration
                {
                    DeviceManagerId = configResponse.DeviceManagerId,
                    Channels = new(),
                    Devices = new(),
                }
            };
            result.Configuration.Channels.Udps.AddRange(configResponse.Channels.Where(_ => _.ChannelType == ChannelType.Udp).Select(_ => ((UdpConfig)_).ToProtobuf()));
            result.Configuration.Channels.SharedUdps.AddRange(configResponse.Channels.Where(_ => _.ChannelType == ChannelType.SharedUdp).Select(_ => ((SharedUdpConfig)_).ToProtobuf()));
            result.Configuration.Channels.SerialOverUdps.AddRange(configResponse.Channels.Where(_ => _.ChannelType == ChannelType.SerialOverUdp).Select(_ => ((SerialOverUdpConfig)_).ToProtobuf()));
            result.Configuration.Devices.Signals = new();
            result.Configuration.Devices.Signals.SerialOverUdpSignals.AddRange(configResponse.Devices.Where(_ => _.ChannelType == ChannelType.SerialOverUdp && _.DeviceType == DeviceType.Signal).Select(_ => ((SignalConfig)_).ToSerialProtobuf()));
            result.Configuration.Devices.Signals.UdpSignals.AddRange(configResponse.Devices.Where(_ => _.ChannelType == ChannelType.Udp && _.DeviceType == DeviceType.Signal).Select(_ => ((SignalConfig)_).ToUdpProtobuf()));
            result.Configuration.Devices.EnvironmentalSensors = new();
            result.Configuration.Devices.EnvironmentalSensors.UdpEnvironmentalSensors.AddRange(configResponse.Devices.Where(_ => _.ChannelType == ChannelType.Udp && _.DeviceType == DeviceType.Ess).Select(_ => ((EssConfig)_).ToUdpProtobuf()));

            return result;
        }

        #region Channels

        public static proto.CommonChannel ToCommonProtobuf(this IBaseChannelConfig config) => new proto.CommonChannel
        {
            FailedPollRate = config.FailedPollRate,
            Id = config.Id,
            Name = config.Name,
            PollErrorThreshold = config.PollErrorThreshold,
            PollRetries = config.PollRetries,
            PrimaryPollRate = config.PrimaryPollRate,
            PriorityPollRate = config.PriorityPollRate,
            Retries = config.Retries,
            SecondaryPollRate = config.SecondaryPollRate,
            TertiaryPollRate = config.TertiaryPollRate,
            TimeFormat = config.TimeFormat.ToProtobuf(),
            Timeout = config.CommRequestTimeout,
        };

        public static proto.CommonIp ToProtobuf(this UdpConfig config) => new proto.CommonIp
        {
            CommonChannel = config.ToCommonProtobuf(),
            SourceIp = config.SourceIp,
            SourcePort = config.SourcePort,
        };

        public static proto.SerialOverUdp ToProtobuf(this SerialOverUdpConfig config) => new proto.SerialOverUdp
        {
            CommonIp = ((UdpConfig)config).ToProtobuf(),
            DestinationIp = config.DestIp,
            DestinationPort = config.DestPort,
        };
        #endregion

        #region Devices

        public static proto.SerialSignal ToSerialProtobuf(this SignalConfig config) => new proto.SerialSignal
        {
            CommonSignal = config.ToCommonSignalProtobuf(),
            CommonSerialDevice = config.ToCommonSerialProtobuf(),
        };

        public static proto.UdpSignal ToUdpProtobuf(this SignalConfig config) => new proto.UdpSignal
        {
            CommonIpDevice = config.ToCommonIpDeviceProtobuf(),
            CommonSignal = config.ToCommonSignalProtobuf(),
        };

        public static proto.UdpEnvironmentalSensor ToUdpProtobuf(this EssConfig config) => new proto.UdpEnvironmentalSensor
        {
            CommonIpDevice = config.ToCommonIpDeviceProtobuf(),
        };

        public static proto.CommonIpDevice ToCommonIpDeviceProtobuf(this BaseDeviceConfig config) => new proto.CommonIpDevice
        {
            CommonDevice = config.ToCommonDeviceProtobuf(),
            CommunityName = config.SnmpCommunityName,
            DeviceIp = config.DeviceIP,
            DevicePort = config.DevicePort ?? 0,
            Password = config.FTPPassword,

            SshPort = config.SSHPort,
            UserName = config.FTPUsername,
        };

        public static proto.CommonDevice ToCommonDeviceProtobuf(this BaseDeviceConfig config) => new proto.CommonDevice
        {
            AllowedTimeDrift = (int)config.AllowedTimeDrift.TotalMilliseconds,
            ChannelId = config.ChannelId,
            CommunicationMode = config.CommMode.ToProtobuf(),
            FailedPollRate = config.FailedPollRate,
            FilteredCommunicationBad = config.FilteredCommBad,
            FilteredCommunicationMarginal = config.FilteredCommMarginal,
            FilteredCommunicationWeightingFactor = config.FilteredCommWeightingFactor,
            Id = config.DeviceId.ToProtobuf(),
            PollErrorThreshold = config.PollErrorThreshold,
            PollRetries = config.DevicePollRetries,
            PrimaryPollRate = config.PrimaryPollRate,
            PriorityPollRate = config.PriorityPollRate,
            Protocol = config.Protocol.ToProtobuf(),
            Retries = config.DeviceRetries,
            SecondaryPollRate = config.SecondaryPollRate,
            Tag = config.ExternalTag,
            TertiaryPollRate = config.TertiaryPollRate,
            TimeFormat = config.DeviceTimeFormat.ToProtobuf(),
            Timeout = config.CommRequestTimeout,
            MaxVbsPerPdu = config.MaxVbsPerPdu,
        };

        public static proto.CommonSignal ToCommonSignalProtobuf(this SignalConfig config) => new proto.CommonSignal
        {
            CollectHighResolutionData = config.IsHighResCtrlEnabled,
            DetectorFaultPolling = config.DetectorFaultPolling,
            DiscoverDynamicObjects = config.DiscoverDynamicObjects,
            MainStreetOverlaps = config.MSGOverlaps,
            MainStreetPhases = config.MSGPhases,
            SideStreetOverlaps = config.SSGOverlaps,
            SideStreetPhases = config.SSGPhases,
            SignalType = config.DeviceSignalType.ToProtobuf(),
            VolumeOccupancyPeriod = config.VolumeOccupancyPeriod,
            AdaptivePolling = config.AdaptivePolling,
        };

        public static proto.CommonSerialDevice ToCommonSerialProtobuf(this SignalConfig config) => new proto.CommonSerialDevice
        {
            CommonDevice = config.ToCommonDeviceProtobuf(),
            DropAddress = config.DeviceDropAddress ?? 0,
        };

        #endregion

        public static int ExtractDMId(this JsonNode json)
        {
            var t = (int)json["DeviceManagerId"];
            return t;
        }

        public static IBaseDeviceConfig[] ExtractDevices(this JsonNode json)
        {
            var t = ((JsonArray)json["Devices"]).ToDevices();
            return t;
        }

        public static IBaseChannelConfig[] ExtractChannels(this JsonNode json)
        {
            var t = ((JsonArray)json["Channels"]).ToChannels();
            return t;
        }
        public static ConfigResponse ToConfigResponse(this ConfigResponseBase configResponseBase) =>
            configResponseBase switch
            {
                ConfigResponse configResponse => configResponse,
                proto.ConfigRequestProto configuration => new ConfigResponse
                {
                    Channels = configuration.Configuration.Channels.ToConfigResponse(),
                    DeviceManagerId = configuration.DeviceManagerId,
                    Devices = configuration.Configuration.Devices.ToConfigResponse()
                },
                _ => new ConfigResponse(),
            };

        public static IBaseChannelConfig[] ToConfigResponse(this proto.Channels channels) =>
            channels.Udps.Select(_ => _.ToConfigResponse(ChannelType.Udp))
            .Concat(channels.SharedUdps.Select(_ => _.ToConfigResponse(ChannelType.SharedUdp)))
            .Concat(channels.SerialOverUdps.Select(_ => _.ToConfigResponse()))
            .ToArray();

        public static IBaseChannelConfig ToConfigResponse(this proto.CommonIp channel, ChannelType channelType) =>
            channelType switch
            {
                ChannelType.Udp => channel.ApplyTo(new UdpConfig()),
                ChannelType.SharedUdp => channel.ApplyTo(new SharedUdpConfig()),
                ChannelType.SerialOverUdp => channel.ApplyTo(new SerialOverUdpConfig()),
                _ => throw new Exception("Unsupported type")
            };

        public static IpConfig ApplyTo(this proto.CommonIp proto, IpConfig config)
        {
            config.SourceIp = proto.SourceIp;
            config.SourcePort = proto.SourcePort;
            proto.CommonChannel.ApplyTo(config);
            return config;
        }

        public static BaseChannelConfig ApplyTo(this proto.CommonChannel proto, BaseChannelConfig config)
        {
            config.Id = proto.Id;
            config.Name = proto.Name;
            config.Retries = proto.Retries;
            config.PollRetries = proto.PollRetries;
            config.CommRequestTimeout = proto.Timeout;
            config.PollErrorThreshold = proto.PollErrorThreshold;
            config.FailedPollRate = proto.FailedPollRate;
            config.PrimaryPollRate = proto.PrimaryPollRate;
            config.SecondaryPollRate = proto.SecondaryPollRate;
            config.PriorityPollRate = proto.PriorityPollRate;
            config.TertiaryPollRate = proto.TertiaryPollRate;
            config.TimeFormat = proto.TimeFormat.ToConfigResponse();
            return config;
        }

        public static IBaseChannelConfig ToConfigResponse(this proto.SerialOverUdp channel) => channel.CommonIp.ApplyTo(new SerialOverUdpConfig()
        {
            DestIp = channel.DestinationIp,
            DestPort = channel.DestinationPort
        });

        public static IBaseDeviceConfig[] ToConfigResponse(this proto.Devices devices) =>
            devices.Signals.ToConfigResponse()
            .Concat(devices.EnvironmentalSensors.ToConfigResponse())
            .ToArray();

        public static IBaseDeviceConfig[] ToConfigResponse(this proto.Signals devices) =>
            devices.UdpSignals.Select(_ => _.ToConfigResponse(ChannelType.Udp))
            .Concat(devices.SerialOverUdpSignals.Select(_ => _.ToConfigResponse(ChannelType.SerialOverUdp)))
            .ToArray();

        public static IBaseDeviceConfig ToConfigResponse(this proto.UdpSignal device, ChannelType channelType) => device.CommonIpDevice.ApplyTo(device.CommonSignal.ApplyTo(new SignalConfig()), channelType);

        public static IBaseDeviceConfig ApplyTo(this proto.CommonIpDevice proto, IBaseDeviceConfig config, ChannelType channelType)
        {
            proto.CommonDevice.ApplyTo(config, channelType);
            config.DeviceIP = proto.DeviceIp;
            config.DevicePort = proto.DevicePort;
            config.SSHPort = proto.SshPort;
            config.SnmpCommunityName = proto.CommunityName;
            config.FTPUsername = proto.UserName;
            config.FTPPassword = proto.Password;
            return config;
        }

        public static ISignalConfig ApplyTo(this proto.CommonSignal proto, ISignalConfig config)
        {
            config.DeviceSubType = (byte)proto.SignalType.ToConfigResponse();
            config.MSGPhases = proto.MainStreetPhases;
            config.SSGPhases = proto.SideStreetPhases;
            config.MSGOverlaps = proto.MainStreetOverlaps;
            config.SSGOverlaps = proto.SideStreetOverlaps;
            config.VolumeOccupancyPeriod = proto.VolumeOccupancyPeriod;
            config.IsHighResCtrlEnabled = proto.CollectHighResolutionData;
            config.DiscoverDynamicObjects = proto.DiscoverDynamicObjects;
            config.DetectorFaultPolling = proto.DetectorFaultPolling;
            config.AdaptivePolling = proto.AdaptivePolling;
            return config;
        }

        public static IBaseDeviceConfig ApplyTo(this proto.CommonDevice proto, IBaseDeviceConfig config, ChannelType channelType)
        {
            config.DeviceId = proto.Id.ToConfigResponse();
            config.ExternalTag = proto.Tag;
            config.ChannelId = proto.ChannelId;
            config.ChannelType = channelType;
            config.CommMode = proto.CommunicationMode.ToConfigResponse();
            config.CommRequestTimeout = proto.Timeout;
            config.DeviceRetries = proto.Retries;
            config.DevicePollRetries = proto.PollRetries;
            config.PollErrorThreshold = proto.PollErrorThreshold;
            config.FailedPollRate = proto.FailedPollRate;
            config.PrimaryPollRate = proto.PrimaryPollRate;
            config.SecondaryPollRate = proto.SecondaryPollRate;
            config.PriorityPollRate = proto.PriorityPollRate;
            config.TertiaryPollRate = proto.TertiaryPollRate;
            config.DeviceTimeFormat = proto.TimeFormat.ToConfigResponse();
            config.Protocol = proto.Protocol.ToConfigResponse();
            config.FilteredCommBad = proto.FilteredCommunicationBad;
            config.FilteredCommMarginal = proto.FilteredCommunicationMarginal;
            config.FilteredCommWeightingFactor = proto.FilteredCommunicationWeightingFactor;
            config.AllowedTimeDrift = TimeSpan.FromMilliseconds(proto.AllowedTimeDrift);
            config.MaxVbsPerPdu = proto.MaxVbsPerPdu == 0 ? 6 : proto.MaxVbsPerPdu;
            return config;
        }

        public static IBaseDeviceConfig ToConfigResponse(this proto.SerialSignal device, ChannelType channelType) => device.CommonSerialDevice.ApplyTo(device.CommonSignal.ApplyTo(new SignalConfig()), ChannelType.SerialOverUdp);

        public static IBaseDeviceConfig ApplyTo(this proto.CommonSerialDevice proto, IBaseDeviceConfig config, ChannelType channelType)
        {
            proto.CommonDevice.ApplyTo(config, channelType);
            config.DeviceDropAddress = proto.DropAddress;
            return config;
        }

        public static IBaseDeviceConfig[] ToConfigResponse(this proto.EnvironmentalSensors devices) =>
            devices.UdpEnvironmentalSensors.Select(_ => _.ToConfigResponse()).ToArray();

        public static IBaseDeviceConfig ToConfigResponse(this proto.UdpEnvironmentalSensor device) => device.CommonIpDevice.ApplyTo(new EssConfig(), ChannelType.Udp);
    }
}
