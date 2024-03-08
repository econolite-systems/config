// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Channels
{
    public interface IBaseChannelConfig
    {
        string BroadcastIPAddress { get; set; }
        int ByteRxTimeout { get; set; }
        ChannelType ChannelType { get; }
        int CommRequestTimeout { get; set; }
        int FailedPollRate { get; set; }
        int Id { get; set; }
        int InnerByteDelay { get; set; }
        bool InnerChannelDelay { get; set; }
        int InnerDeviceDelay { get; set; }
        int MaxExpectedPacketSize { get; set; }
        string Name { get; set; }
        int PollErrorThreshold { get; set; }
        int PollRetries { get; set; }
        int PrimaryPollRate { get; set; }
        int PriorityPollRate { get; set; }
        Protocol Protocol { get; set; }
        int Retries { get; set; }
        int SecondaryPollRate { get; set; }
        int TertiaryPollRate { get; set; }
        DeviceTimeFormat TimeFormat { get; set; }
    }
}
