// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using System;

namespace Econolite.Ode.Config.Devices
{
    public class DmsConfig : BaseDeviceConfig, IDmsConfig
    {
        public override DeviceType DeviceType => DeviceType.Dms;

        public DmsConfig(string externalTag, Guid deviceId, byte deviceSubType, CommMode commMode, ChannelType channelType, Protocol protocol, string deviceIp, int? devicePort, int? deviceDropAddress, int deviceRetries, int devicePollRetries, int primaryPollRate, int secondaryPollRate, int tertiaryPollRate, int priorityPollRate, int failedPollRate, int channelId, int pollErrorThreshold, int commRequestTimeout, DeviceTimeFormat deviceTimeFormat, string broadcastIpAddress, string snmpCommunityName, string ftpUsername, string ftpPassword, string sshHostKey, int maxVbsPerPdu, TimeSpan backupPreventPeriod, int filteredCommWeightingFactor, int filteredCommMarginal, int filteredCommBad, MessageMemoryType blankType, ushort blankIndex, ushort blankCRC, ushort quickMessageIndex, TimeSpan allowTimeDrift, int sshPort)
            : base(externalTag: externalTag, deviceId: deviceId, deviceSubType: deviceSubType, commMode: commMode, channelType: channelType, protocol: protocol, deviceIp: deviceIp, devicePort: devicePort, deviceDropAddress: deviceDropAddress, deviceRetries: deviceRetries, devicePollRetries: devicePollRetries, primaryPollRate: primaryPollRate, secondaryPollRate: secondaryPollRate, tertiaryPollRate: tertiaryPollRate, priorityPollRate: priorityPollRate, failedPollRate: failedPollRate, channelId: channelId, pollErrorThreshold: pollErrorThreshold, commRequestTimeout: commRequestTimeout, deviceTimeFormat: deviceTimeFormat, broadcastIpAddress: broadcastIpAddress, snmpCommunityName: snmpCommunityName, ftpUsername: ftpUsername, ftpPassword: ftpPassword, sshHostKey: sshHostKey, maxVbsPerPdu: maxVbsPerPdu, backupPreventPeriod: backupPreventPeriod, filteredCommWeightingFactor: filteredCommWeightingFactor, filteredCommMarginal: filteredCommMarginal, filteredCommBad: filteredCommBad, allowTimeDrift: allowTimeDrift, sshPort: sshPort)
        {
            BlankType = blankType;
            BlankIndex = blankIndex;
            BlankCRC = blankCRC;
            QuickMessageIndex = quickMessageIndex;
        }

        #region Properties
        /// <summary>
        /// Type of DMS - BOS, CMS, VMS, 
        /// </summary>
        public DmsType DeviceSignType
        {
            get
            {
                return (DmsType)DeviceSubType;
            }
            set
            {
                DeviceSubType = (byte)value;
            }
        }

        /// <summary>
        /// Message memory type to use for blanking the sign
        /// </summary>
        public MessageMemoryType BlankType { get; set; }

        /// <summary>
        /// Message memory index to use for blanking the sign
        /// </summary>
        public ushort BlankIndex { get; set; }

        /// <summary>
        /// CRC value to use when blanking the sign
        /// </summary>
        public ushort BlankCRC { get; set; }

        /// <summary>
        /// Message memory index to use for Quick Messages
        /// </summary>
        public ushort QuickMessageIndex { get; set; }

        #endregion
    }
}
