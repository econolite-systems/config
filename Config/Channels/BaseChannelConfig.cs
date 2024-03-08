// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Channels
{
    public abstract class BaseChannelConfig : IBaseChannelConfig
    {
        public abstract ChannelType ChannelType { get; }

        protected BaseChannelConfig(int id, string name, Protocol protocol, int retries, int pollRetries, int innerByteDelay, int innerDeviceDelay, bool innerChannelDelay, int commRequestTimeout, int byteRxTimeout, int maxExpectedPacketSWize, int pollErrorThreshold, int failedPollRate, int primaryPollRate, int secondaryPollRate, int priorityPollRate, int tertiaryPollRate, string broadcastIpAddress, DeviceTimeFormat timeFormat)
        {
            Id = id;
            Name = name;
            Protocol = protocol;
            Retries = retries;
            PollRetries = pollRetries;
            InnerByteDelay = innerByteDelay;
            InnerDeviceDelay = innerDeviceDelay;
            InnerChannelDelay = innerChannelDelay;
            CommRequestTimeout = commRequestTimeout;
            ByteRxTimeout = byteRxTimeout;
            MaxExpectedPacketSize = maxExpectedPacketSWize;
            PollErrorThreshold = pollErrorThreshold;
            FailedPollRate = failedPollRate;
            PrimaryPollRate = primaryPollRate;
            SecondaryPollRate = secondaryPollRate;
            PriorityPollRate = priorityPollRate;
            TertiaryPollRate = tertiaryPollRate;
            BroadcastIPAddress = broadcastIpAddress;
            TimeFormat = timeFormat;
        }

        // Empty constructor for serialization
        protected BaseChannelConfig()
        {
        }

        #region Properties

        /// <summary>
        /// Locally unique identifier for the channel.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the channel.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the protocol type being used on the channel, SNMP, STMP, etc.
        /// </summary>
        public Protocol Protocol { get; set; }

        /// <summary>
        /// Gets or sets when a send failure occurs this value determines how many
        /// times the message will try to be sent again.
        /// </summary>
        public int Retries { get; set; }

        /// <summary>
        /// Gets or sets when a send failure occurs this value determines how many
        /// times the message will try to be sent again.
        /// </summary>
        public int PollRetries { get; set; }

        /// <summary>
        /// Gets or sets the delay between sent characters.  This is mainly for Oasis, as the 
        /// controller hardware cannot handle the max byte send rate.
        /// </summary>
        public int InnerByteDelay { get; set; }

        /// <summary>
        /// Gets or sets the delay from receipt of one packet to sending another.
        /// </summary>
        public int InnerDeviceDelay { get; set; }

        /// <summary>
        /// Get or sets the delay between messages on a channel.
        /// </summary>
        public bool InnerChannelDelay { get; set; }

        /// <summary>
        /// Gets or sets the timeout for a device response.
        /// </summary>
        public int CommRequestTimeout { get; set; }

        /// <summary>
        /// Gets or sets the response times out if an inter-byte receive time (after receipt of 
        /// the first byte) exceeds this value. Only for serial devices.
        /// </summary>
        public int ByteRxTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximum packet timeout for serial device begins upon receipt of the 
        /// first byte.  The timeout is computed as this number of bytes times the 
        /// time for one byte which is computed form the baud rate.  Only used by 
        /// serial devices.
        /// </summary>
        public int MaxExpectedPacketSize { get; set; }

        public int PollErrorThreshold { get; set; }

        public int FailedPollRate { get; set; }

        public int PrimaryPollRate { get; set; }

        public int SecondaryPollRate { get; set; }

        public int PriorityPollRate { get; set; }

        public int TertiaryPollRate { get; set; }

        public string BroadcastIPAddress { get; set; }

        public DeviceTimeFormat TimeFormat { get; set; }

        #endregion
    }
}
