// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Devices;
using System.Net;

namespace Econolite.Ode.Config.Channels
{
    public class SerialOverUdpConfig : UdpConfig, ISerialOverConfig
    {
        public SerialOverUdpConfig(int id, string name, Protocol protocol, int retries, int pollRetries, int innerByteDelay, int innerDeviceDelay, bool innerChannelDelay, int commRequestTimeout, int byteRxTimeout, int maxExpectedPacketSize, int pollErrorThreshold, int failedPollRate, int primaryPollRate, int secondaryPollRate, int priorityPollRate, int tertiaryPollRate, string broadcastIpAddress, DeviceTimeFormat timeFormat, string sourceIp, int sourcePort, string destIp, int destPort)
            : base(id, name, protocol, retries, pollRetries, innerByteDelay, innerDeviceDelay, innerChannelDelay, commRequestTimeout, byteRxTimeout, maxExpectedPacketSize, pollErrorThreshold, failedPollRate, primaryPollRate, secondaryPollRate, priorityPollRate, tertiaryPollRate, broadcastIpAddress, timeFormat, sourceIp, sourcePort)
        {
            DestIp = destIp;
            DestPort = destPort;
        }

        // Empty constructor for serialization
        public SerialOverUdpConfig()
        {
        }

        public override ChannelType ChannelType => ChannelType.SerialOverUdp;

        /// <summary>
        /// Gets or sets the IP Address of the channel.
        /// </summary>
        public string DestIp { get; set; }

        /// <summary>
        /// Gets or sets the port of the channel.
        /// </summary>
        public int DestPort { get; set; }
    }
}
