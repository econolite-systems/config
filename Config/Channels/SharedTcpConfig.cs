// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Channels
{
    public class SharedTcpConfig : IpConfig
    {
        public SharedTcpConfig(int id, string name, Protocol protocol, int retries, int pollRetries, int innerByteDelay, int innerDeviceDelay, bool innerChannelDelay, int commRequestTimeout, int byteRxTimeout, int maxExpectedPacketSize, int pollErrorThreshold, int failedPollRate, int primaryPollRate, int secondaryPollRate, int priorityPollRate, int teriaryPollRate, string broadcastIpAddress, DeviceTimeFormat timeFormat, string sourceIp, int sourcePort)
            : base(id, name, protocol, retries, pollRetries, innerByteDelay, innerDeviceDelay, innerChannelDelay, commRequestTimeout, byteRxTimeout, maxExpectedPacketSize, pollErrorThreshold, failedPollRate, primaryPollRate, secondaryPollRate, priorityPollRate, teriaryPollRate, broadcastIpAddress, timeFormat, sourceIp, sourcePort)
        {

        }
        public override ChannelType ChannelType => ChannelType.SharedTcp;
    }
}
