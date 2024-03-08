// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.

using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Channels
{
    public class UdpConfig : IpConfig
    {
        public UdpConfig(int id, string name, Protocol protocol, int retries, int pollRetries, int innerByteDelay, int innerDeviceDelay, bool innerChannelDelay, int commRequestTimeout, int byteRxTimeout, int maxExpectedPacketSize, int pollErrorThreshold, int failedPollRate, int primaryPollRate, int secondaryPollRate, int priorityPollRate, int tertiaryPollRate, string broadcastIpAddress, DeviceTimeFormat timeFormat, string sourceIp, int sourcePort)
            : base(id, name, protocol, retries, pollRetries, innerByteDelay, innerDeviceDelay, innerChannelDelay, commRequestTimeout, byteRxTimeout, maxExpectedPacketSize, pollErrorThreshold, failedPollRate, primaryPollRate, secondaryPollRate, priorityPollRate, tertiaryPollRate, broadcastIpAddress, timeFormat, sourceIp, sourcePort)
        {

        }

        // Empty constructor for serialization
        public UdpConfig()
        {
        }

        public override ChannelType ChannelType => ChannelType.Udp;
    }
}
