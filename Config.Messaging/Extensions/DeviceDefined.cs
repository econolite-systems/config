// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using Econolite.Ode.Config.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

namespace Econolite.Ode.Config.Messaging.Extensions
{
    public static class DeviceDefined
    {
        public static IBaseDeviceConfig[] ToDevices(this JsonArray json)
        {
            var result = new List<IBaseDeviceConfig>(json.Count);
            foreach (var device in json)
            {
                var devicetype = Enum.Parse<DeviceType>(device["DeviceType"]?.ToString() ?? "-1");
                switch (devicetype)
                {
                    case DeviceType.Signal:
                        result.Add(new SignalConfig(
                            externalTag: (string)device["ExternalTag"],
                            deviceId: (Guid?)device["DeviceId"] ?? Guid.Empty,
                            deviceSubType: (byte?)device["DeviceSubType"] ?? 0,
                            commMode: Enum.Parse<CommMode>(device["CommMode"]?.ToString() ?? "0"),
                            channelType: Enum.Parse<ChannelType>(device["ChannelType"]?.ToString() ?? "-1"),
                            protocol: Enum.Parse<Protocol>(device["Protocol"]?.ToString() ?? "0"),
                            deviceIp: (string)device["DeviceIP"] ?? string.Empty,
                            devicePort: (int?)device["DevicePort"],
                            deviceDropAddress: (int?)device["DeviceDropAddress"] ?? 0,
                            deviceRetries: (int?)device["DeviceRetries"] ?? 0,
                            devicePollRetries: (int?)device["DevicePollRetries"] ?? 0,
                            primaryPollRate: (int?)device["PrimaryPollRate"] ?? 0,
                            secondaryPollRate: (int?)device["SecondaryPollRate"] ?? 0,
                            tertiaryPollRate: (int?)device["TertiaryPollRate"] ?? 0,
                            priorityPollRate: (int?)device["PriorityPollRate"] ?? 0,
                            failedPollRate: (int?)device["FailedPollRate"] ?? 0,
                            channelId: (int?)device["ChannelId"] ?? 0,
                            pollErrorThreshold: (int?)device["PollErrorThreshold"] ?? 0,
                            commRequestTimeout: (int?)device["CommRequestTimeout"] ?? 0,
                            deviceTimeFormat: Enum.Parse<DeviceTimeFormat>(device["TimeFormat"]?.ToString() ?? "TimeDefault"),
                            broadcastIpAddress: (string)device["BroadcastIPAddress"] ?? string.Empty,
                            snmpCommunityName: (string)device["SnmpCommunityName"] ?? string.Empty,
                            ftpUsername: (string)device["FTPUsername"] ?? string.Empty,
                            ftpPassword: (string)device["FTPPassword"] ?? string.Empty,
                            sshHostKey: (string)device["SSHHostKey"] ?? string.Empty,
                            sshPort: (int?)device["SSHPort"] ?? 0,
                            maxVbsPerPdu: (int?)device["MaxVbsPerPdu"] ?? 6,
                            backupPreventPeriod: TimeSpan.Zero,
                            dynObjDefIds: ((JsonArray)device["DynObjDefIds"])?.Select(x => (int)x).ToArray() ?? Array.Empty<int>(),
                            dynamicDetectorReferences: Array.Empty<byte>(),
                            msgPhases: (ushort?)device["MSGPhases"] ?? 0,
                            msgOverlaps: (ushort?)device["MSGOverlaps"] ?? 0,
                            ssgPhases: (ushort?)device["SSGPhases"] ?? 0,
                            ssgOverlaps: (ushort?)device["SSGOverlaps"] ?? 0,
                            isHighResCtrlEnabled: (bool?)device["IsHighResCtrlEnabled"] ?? false,
                            detectors: new Dictionary<byte, Detector>(),
                            samplingDetectors: new Dictionary<byte, Detector>(),
                            volumeOccupancyPeriod: (int?)device["VolumeOccupancyPeriod"] ?? 0,
                            filteredCommWeightingFactor: (int?)device["FilteredCommWeightingFactor"] ?? 0,
                            filteredCommMarginal: (int?)device["FilteredCommMarginal"] ?? 0,
                            filteredCommBad: (int?)device["FilteredCommBad"] ?? 0,
                            discoverDynamicObjects: (bool?)device["DiscoverDynamicObjects"] ?? false,
                            allowTimeDrift: TimeSpan.Parse((string)device["AllowedTimeDrift"] ?? "00:00:00"),
                            detectorFaultPolling: (bool?)device["DetectorFaultPolling"] ?? false,
                            adaptivePolling: (bool?)device["AdaptivePolling"] ?? false
                            ));
                        break;
                    case DeviceType.RampMeter:
                        result.Add(new RampMeterConfig(
                            externalTag: (string)device["ExternalTag"],
                            deviceId: (Guid?)device["DeviceId"] ?? Guid.Empty,
                            deviceSubType: (byte?)device["DeviceSubType"] ?? 0,
                            commMode: Enum.Parse<CommMode>(device["CommMode"]?.ToString() ?? "0"),
                            channelType: Enum.Parse<ChannelType>(device["ChannelType"]?.ToString() ?? "-1"),
                            protocol: Enum.Parse<Protocol>(device["Protocol"]?.ToString() ?? "0"),
                            deviceIp: (string)device["DeviceIP"] ?? string.Empty,
                            devicePort: (int?)device["DevicePort"],
                            deviceDropAddress: (int?)device["DeviceDropAddress"] ?? 0,
                            deviceRetries: (int?)device["DeviceRetries"] ?? 0,
                            devicePollRetries: (int?)device["DevicePollRetries"] ?? 0,
                            primaryPollRate: (int?)device["PrimaryPollRate"] ?? 0,
                            secondaryPollRate: (int?)device["SecondaryPollRate"] ?? 0,
                            tertiaryPollRate: (int?)device["TertiaryPollRate"] ?? 0,
                            priorityPollRate: (int?)device["PriorityPollRate"] ?? 0,
                            failedPollRate: (int?)device["FailedPollRate"] ?? 0,
                            channelId: (int?)device["ChannelId"] ?? 0,
                            pollErrorThreshold: (int?)device["PollErrorThreshold"] ?? 0,
                            commRequestTimeout: (int?)device["CommRequestTimeout"] ?? 0,
                            deviceTimeFormat: Enum.Parse<DeviceTimeFormat>(device["TimeFormat"]?.ToString() ?? "TimeDefault"),
                            broadcastIpAddress: (string)device["BroadcastIPAddress"] ?? string.Empty,
                            snmpCommunityName: (string)device["SnmpCommunityName"] ?? string.Empty,
                            ftpUsername: (string)device["FTPUsername"] ?? string.Empty,
                            ftpPassword: (string)device["FTPPassword"] ?? string.Empty,
                            sshHostKey: (string)device["SSHHostKey"] ?? string.Empty,
                            sshPort: (int?)device["SSHPort"] ?? 0,
                            maxVbsPerPdu: (int?)device["MaxVbsPerPdu"] ?? 6,
                            backupPreventPeriod: TimeSpan.Zero,
                            filteredCommWeightingFactor: (int?)device["FilteredCommWeightingFactor"] ?? 0,
                            filteredCommMarginal: (int?)device["FilteredCommMarginal"] ?? 0,
                            filteredCommBad: (int?)device["FilteredCommBad"] ?? 0,
                            allowTimeDrift: TimeSpan.Parse((string)device["AllowedTimeDrift"] ?? "00:00:00")
                            ));
                        break;
                    case DeviceType.Ess:
                        result.Add(new EssConfig(
                            externalTag: (string)device["ExternalTag"],
                            deviceId: (Guid?)device["DeviceId"] ?? Guid.Empty,
                            deviceSubType: (byte?)device["DeviceSubType"] ?? 0,
                            commMode: Enum.Parse<CommMode>(device["CommMode"]?.ToString() ?? "0"),
                            channelType: Enum.Parse<ChannelType>(device["ChannelType"]?.ToString() ?? "-1"),
                            protocol: Enum.Parse<Protocol>(device["Protocol"]?.ToString() ?? "0"),
                            deviceIp: (string)device["DeviceIP"] ?? string.Empty,
                            devicePort: (int?)device["DevicePort"],
                            deviceDropAddress: (int?)device["DeviceDropAddress"] ?? 0,
                            deviceRetries: (int?)device["DeviceRetries"] ?? 0,
                            devicePollRetries: (int?)device["DevicePollRetries"] ?? 0,
                            primaryPollRate: (int?)device["PrimaryPollRate"] ?? 0,
                            secondaryPollRate: (int?)device["SecondaryPollRate"] ?? 0,
                            tertiaryPollRate: (int?)device["TertiaryPollRate"] ?? 0,
                            priorityPollRate: (int?)device["PriorityPollRate"] ?? 0,
                            failedPollRate: (int?)device["FailedPollRate"] ?? 0,
                            channelId: (int?)device["ChannelId"] ?? 0,
                            pollErrorThreshold: (int?)device["PollErrorThreshold"] ?? 0,
                            commRequestTimeout: (int?)device["CommRequestTimeout"] ?? 0,
                            deviceTimeFormat: Enum.Parse<DeviceTimeFormat>(device["TimeFormat"]?.ToString() ?? "TimeDefault"),
                            broadcastIpAddress: (string)device["BroadcastIPAddress"] ?? string.Empty,
                            snmpCommunityName: (string)device["SnmpCommunityName"] ?? string.Empty,
                            ftpUsername: (string)device["FTPUsername"] ?? string.Empty,
                            ftpPassword: (string)device["FTPPassword"] ?? string.Empty,
                            sshHostKey: (string)device["SSHHostKey"] ?? string.Empty,
                            sshPort: (int?)device["SSHPort"] ?? 0,
                            maxVbsPerPdu: (int?)device["MaxVbsPerPdu"] ?? 6,
                            backupPreventPeriod: TimeSpan.Zero,
                            filteredCommWeightingFactor: (int?)device["FilteredCommWeightingFactor"] ?? 0,
                            filteredCommMarginal: (int?)device["FilteredCommMarginal"] ?? 0,
                            filteredCommBad: (int?)device["FilteredCommBad"] ?? 0,
                            allowTimeDrift: TimeSpan.Parse((string)device["AllowedTimeDrift"] ?? "00:00:00")
                            ));
                        break;
                    default:
                        break;
                }
            }

            return result.ToArray();
        }
    }
}
