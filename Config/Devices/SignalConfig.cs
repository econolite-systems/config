// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using System;
using System.Collections.Generic;

namespace Econolite.Ode.Config.Devices
{
    public class SignalConfig : BaseDeviceConfig, ISignalConfig
    {
        public override DeviceType DeviceType => DeviceType.Signal;
        public SignalConfig(string externalTag, Guid deviceId, byte deviceSubType, CommMode commMode, ChannelType channelType, Protocol protocol, string deviceIp, int? devicePort, int? deviceDropAddress, int deviceRetries, int devicePollRetries, int primaryPollRate, int secondaryPollRate, int tertiaryPollRate, int priorityPollRate, int failedPollRate, int channelId, int pollErrorThreshold, int commRequestTimeout, DeviceTimeFormat deviceTimeFormat, string broadcastIpAddress, string snmpCommunityName, string ftpUsername, string ftpPassword, string sshHostKey, int maxVbsPerPdu, TimeSpan backupPreventPeriod, int filteredCommWeightingFactor, int filteredCommMarginal, int filteredCommBad, TimeSpan allowTimeDrift, int sshPort, int[] dynObjDefIds, byte[] dynamicDetectorReferences, ushort msgPhases, ushort msgOverlaps, ushort ssgPhases, ushort ssgOverlaps, bool isHighResCtrlEnabled, Dictionary<byte, Detector> detectors, Dictionary<byte, Detector> samplingDetectors, int volumeOccupancyPeriod, bool discoverDynamicObjects, bool detectorFaultPolling, bool adaptivePolling)
            : base(externalTag: externalTag, deviceId: deviceId, deviceSubType: deviceSubType, commMode: commMode, channelType: channelType, protocol: protocol, deviceIp: deviceIp, devicePort: devicePort, deviceDropAddress: deviceDropAddress, deviceRetries: deviceRetries, devicePollRetries: devicePollRetries, primaryPollRate: primaryPollRate, secondaryPollRate: secondaryPollRate, tertiaryPollRate: tertiaryPollRate, priorityPollRate: priorityPollRate, failedPollRate: failedPollRate, channelId: channelId, pollErrorThreshold: pollErrorThreshold, commRequestTimeout: commRequestTimeout, deviceTimeFormat: deviceTimeFormat, broadcastIpAddress: broadcastIpAddress, snmpCommunityName: snmpCommunityName, ftpUsername: ftpUsername, ftpPassword: ftpPassword, sshHostKey: sshHostKey, maxVbsPerPdu: maxVbsPerPdu, backupPreventPeriod: backupPreventPeriod, filteredCommWeightingFactor: filteredCommWeightingFactor, filteredCommMarginal: filteredCommMarginal, filteredCommBad: filteredCommBad, allowTimeDrift: allowTimeDrift, sshPort: sshPort)
        {
            DynObjDefIds = dynObjDefIds;
            DynamicDetectorReferences = dynamicDetectorReferences;
            MSGPhases = msgPhases;
            MSGOverlaps = msgOverlaps;
            SSGPhases = ssgPhases;
            SSGOverlaps = ssgOverlaps;
            IsHighResCtrlEnabled = isHighResCtrlEnabled;
            Detectors = detectors;
            SamplingDetectors = samplingDetectors;
            VolumeOccupancyPeriod = volumeOccupancyPeriod;
            DiscoverDynamicObjects = discoverDynamicObjects;
            DetectorFaultPolling = detectorFaultPolling;
            AdaptivePolling = adaptivePolling;
        }

        // Empty constructor for serialization
        public SignalConfig()
        {
        }

        #region Properties
        /// <summary>
        /// Type of signal (ASC/2, ASC/3, Eagle, Oasis, W4, etc
        /// </summary>
        public SignalType DeviceSignalType
        {
            get => (SignalType)DeviceSubType;
            set => DeviceSubType = (byte)value;
        }

        /// <summary>
        /// Determines what DynObjDefID poll to use
        /// </summary>
        public int[] DynObjDefIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] DynamicDetectorReferences { get; set; }

        public ulong MSGPhases { get; set; }
        public ulong MSGOverlaps { get; set; }
        public ulong SSGPhases { get; set; }
        public ulong SSGOverlaps { get; set; }

        /// <summary>
        /// Set to true to enable MOE logging for ASC/3 and Cobalt controllers
        /// </summary>
        public bool IsHighResCtrlEnabled { get; set; }

        /// <summary>
        /// Detectors defined for this device
        /// </summary>
        public Dictionary<byte, Detector> Detectors { get; }
        public Dictionary<byte, Detector> SamplingDetectors { get; }

        public int VolumeOccupancyPeriod { get; set; }

        public bool DiscoverDynamicObjects { get; set; }

        public bool DetectorFaultPolling { get; set; }

        public bool AdaptivePolling { get; set; }

        #endregion
    }
}
