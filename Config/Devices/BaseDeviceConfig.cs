// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using System;

namespace Econolite.Ode.Config.Devices
{
    public abstract class BaseDeviceConfig : IBaseDeviceConfig
    {
        public abstract DeviceType DeviceType { get; }
        public BaseDeviceConfig(string externalTag, Guid deviceId, byte deviceSubType, CommMode commMode, ChannelType channelType, Protocol protocol, string deviceIp, int? devicePort, int? deviceDropAddress, int deviceRetries, int devicePollRetries, int primaryPollRate, int secondaryPollRate, int tertiaryPollRate, int priorityPollRate, int failedPollRate, int channelId, int pollErrorThreshold, int commRequestTimeout, DeviceTimeFormat deviceTimeFormat, string broadcastIpAddress, string snmpCommunityName, string ftpUsername, string ftpPassword, string sshHostKey, int maxVbsPerPdu, TimeSpan backupPreventPeriod, int filteredCommWeightingFactor, int filteredCommMarginal, int filteredCommBad, TimeSpan allowTimeDrift, int sshPort)
        {
            ExternalTag = externalTag;
            DeviceId = deviceId;
            DeviceSubType = deviceSubType;
            CommMode = commMode;
            ChannelType = channelType;
            Protocol = protocol;
            DeviceIP = deviceIp;
            DevicePort = devicePort;
            DeviceDropAddress = deviceDropAddress;
            DeviceRetries = deviceRetries;
            DevicePollRetries = devicePollRetries;
            PrimaryPollRate = primaryPollRate;
            SecondaryPollRate = secondaryPollRate;
            TertiaryPollRate = tertiaryPollRate;
            PriorityPollRate = priorityPollRate;
            FailedPollRate = failedPollRate;
            ChannelId = channelId;
            PollErrorThreshold = pollErrorThreshold;
            CommRequestTimeout = commRequestTimeout;
            DeviceTimeFormat = deviceTimeFormat;
            BroadcastIPAddress = broadcastIpAddress;
            SnmpCommunityName = snmpCommunityName;
            FTPUsername = ftpUsername;
            FTPPassword = ftpPassword;
            SSHHostKey = sshHostKey;
            SSHPort = sshPort;
            MaxVbsPerPdu = maxVbsPerPdu;
            BackupPreventPeriod = backupPreventPeriod;
            FilteredCommWeightingFactor = filteredCommWeightingFactor;
            FilteredCommMarginal = filteredCommMarginal;
            FilteredCommBad = filteredCommBad;
            AllowedTimeDrift = allowTimeDrift;
            SSHPort = sshPort;
        }

        public BaseDeviceConfig() { }

        // Simple method used in writing information to the logs
        public CommAddress ToCommAddress()
        {
            return new CommAddress(DeviceIP, DevicePort, DeviceDropAddress, Protocol);
        }

        public string ExternalTag { get; set; }

        /// <summary>
        /// Sub type of device.  If signal, ASC/2, ASC/3, W4. If DMS, BOS, CMS, VMS, etc.
        /// </summary>
        public byte DeviceSubType { get; set; }

        /// <summary>
        /// Id of the device.  Unique within the system
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Mode the device is in (online, offline, standby)
        /// </summary>
        public CommMode CommMode { get; set; }

        /// <summary>
        /// Type of channel this device uses on the Comm server (IP, serial, modem)
        /// </summary>
        public ChannelType ChannelType { get; set; }

        /// <summary>
        /// Protocol of channel that this device uses on the comm server.
        /// </summary>
        public Protocol Protocol { get; set; }

        /// <summary>
        /// Destination IP address for this device if using IP channel
        /// </summary>
        public string DeviceIP { get; set; }

        /// <summary>
        /// Destination port for this device if using IP channel
        /// </summary>
        public int? DevicePort { get; set; }

        /// <summary>
        /// Serial drop address for this device
        /// </summary>
        public int? DeviceDropAddress { get; set; }

        /// <summary>
        /// Number of retries for communication with this device
        /// </summary>
        public int DeviceRetries { get; set; }

        /// <summary>
        /// Number of poll retries for communication with this device
        /// </summary>
        public int DevicePollRetries { get; set; }

        public int PrimaryPollRate { get; set; }
        public int SecondaryPollRate { get; set; }
        public int TertiaryPollRate { get; set; }
        //public int QuaternaryPollRate { get; set; }

        /// <summary>
        /// Priority Poll Factor
        /// used to poll the device at a higher rate
        /// </summary>
        public int PriorityPollRate { get; set; }

        /// <summary>
        /// Device Adaptive Poll Rate
        /// what to set the poll rate too 
        /// if PollErrorThreshold has been met
        /// </summary>
        public int FailedPollRate { get; set; }

        public int ChannelId { get; set; }

        /// <summary>
        /// The number of consecutive failed poll requests
        /// at which point the polling manager will adapt its polling rate
        /// </summary>
        public int PollErrorThreshold { get; set; }

        /// <summary>
        /// The number of retries on a poll before
        /// Poll Error Threshold is met
        /// </summary>
        public int CommRequestTimeout { get; set; }

        /// <summary>
        /// How the time should be sent to the device (UTC, local, ACT)
        /// </summary>
        public DeviceTimeFormat DeviceTimeFormat { get; set; }

        /// <summary>
        /// IP address to use when broadcasting to this device
        /// </summary>
        public string BroadcastIPAddress { get; set; }

        /// <summary>
        /// SNMP community to which this device belongs
        /// </summary>
        public string SnmpCommunityName { get; set; }

        /// <summary>
        /// FTP Username
        /// </summary>
        public string FTPUsername { get; set; }

        /// <summary>
        /// FTP Password
        /// </summary>
        public string FTPPassword { get; set; }

        public string SSHHostKey { get; set; }

        public int SSHPort { get; set; }

        public int MaxVbsPerPdu { get; set; }

        public TimeSpan BackupPreventPeriod { get; set; }
        public int FilteredCommBad { get; set; }
        public int FilteredCommMarginal { get; set; }
        public int FilteredCommWeightingFactor { get; set; }
        public TimeSpan AllowedTimeDrift { get; set; }
    }
}
