// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using System;

namespace Econolite.Ode.Config.Devices
{
    public class DataCollectingConfig : BaseDeviceConfig
    {
        public override DeviceType DeviceType => DeviceType.DataCollectingStation;
        public DataCollectingConfig(string externalTag, Guid deviceId, byte deviceSubType, CommMode commMode, ChannelType channelType, Protocol protocol, string deviceIp, int? devicePort, int? deviceDropAddress, int deviceRetries, int devicePollRetries, int primaryPollRate, int secondaryPollRate, int tertiaryPollRate, int priorityPollRate, int failedPollRate, int channelId, int pollErrorThreshold, int commRequestTimeout, DeviceTimeFormat deviceTimeFormat, string broadcastIpAddress, string snmpCommunityName, string ftpUsername, string ftpPassword, string sshHostKey, int maxVbsPerPdu, TimeSpan backupPreventPeriod, int filteredCommWeightingFactor, int filteredCommMarginal, int filteredCommBad, TimeSpan allowTimeDrift, int sshPort, string cpuId, Detector[] detectors)
            : base(externalTag: externalTag, deviceId: deviceId, deviceSubType: deviceSubType, commMode: commMode, channelType: channelType, protocol: protocol, deviceIp: deviceIp, devicePort: devicePort, deviceDropAddress: deviceDropAddress, deviceRetries: deviceRetries, devicePollRetries: devicePollRetries, primaryPollRate: primaryPollRate, secondaryPollRate: secondaryPollRate, tertiaryPollRate: tertiaryPollRate, priorityPollRate: priorityPollRate, failedPollRate: failedPollRate, channelId: channelId, pollErrorThreshold: pollErrorThreshold, commRequestTimeout: commRequestTimeout, deviceTimeFormat: deviceTimeFormat, broadcastIpAddress: broadcastIpAddress, snmpCommunityName: snmpCommunityName, ftpUsername: ftpUsername, ftpPassword: ftpPassword, sshHostKey: sshHostKey, maxVbsPerPdu: maxVbsPerPdu, backupPreventPeriod: backupPreventPeriod, filteredCommWeightingFactor: filteredCommWeightingFactor, filteredCommMarginal: filteredCommMarginal, filteredCommBad: filteredCommBad, allowTimeDrift: allowTimeDrift, sshPort: sshPort)
        {
            CpuId = cpuId;
            Detectors = detectors;
        }

        #region Properties
        /// <summary>
        /// Type of Data Collection Station
        /// </summary>
        public DataCollectionStationType DataCollectionStationType
        {
            get
            {
                return (DataCollectionStationType)DeviceSubType;
            }
            set
            {
                DeviceSubType = (byte)value;
            }
        }

        /// <summary>
        /// Autoscope CPU id
        /// </summary>
        public string CpuId { get; set; }

        public Detector[] Detectors { get; set; }

        #endregion

    }
}
