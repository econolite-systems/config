// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Channels
{
    public abstract class IpConfig : BaseChannelConfig
    {
        protected IpConfig(int id, string name, Protocol protocol, int retries, int pollRetries, int innerByteDelay, int innerDeviceDelay, bool innerChannelDelay, int commRequestTimeout, int byteRxTimeout, int maxExpectedPacketSize, int pollErrorThreshold, int failedPollRate, int primaryPollRate, int secondaryPollRate, int priorityPollRate, int tertiaryPollRate, string broadcastIpAddress, DeviceTimeFormat timeFormat, string sourceIp, int sourcePort)
            : base(id, name, protocol, retries, pollRetries, innerByteDelay, innerDeviceDelay, innerChannelDelay, commRequestTimeout, byteRxTimeout, maxExpectedPacketSize, pollErrorThreshold, failedPollRate, primaryPollRate, secondaryPollRate, priorityPollRate, tertiaryPollRate, broadcastIpAddress, timeFormat)
        {
            SourceIp = sourceIp;
            SourcePort = sourcePort;
        }

        // Empty constructor for serialization
        protected IpConfig()
        {
        }

        /// <summary>
        /// Gets or sets the IP Address of the channel.
        /// </summary>
        public string SourceIp { get; set; } = "0.0.0.0";

        /// <summary>
        /// Gets or sets the port of the channel.
        /// </summary>
        public int SourcePort { get; set; } = 0;
    }
}
