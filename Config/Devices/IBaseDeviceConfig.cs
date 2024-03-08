// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using System;

namespace Econolite.Ode.Config.Devices
{
    public interface IBaseDeviceConfig
    {
        string ExternalTag { get; set; }
        string BroadcastIPAddress { get; set; }
        int ChannelId { get; set; }
        ChannelType ChannelType { get; set; }
        CommMode CommMode { get; set; }
        int CommRequestTimeout { get; set; }
        int? DeviceDropAddress { get; set; }
        Guid DeviceId { get; set; }
        string DeviceIP { get; set; }
        int DevicePollRetries { get; set; }
        int? DevicePort { get; set; }
        int DeviceRetries { get; set; }
        byte DeviceSubType { get; set; }
        DeviceTimeFormat DeviceTimeFormat { get; set; }
        DeviceType DeviceType { get; }
        int FailedPollRate { get; set; }
        string FTPUsername { get; set; }
        string FTPPassword { get; set; }
        int PollErrorThreshold { get; set; }
        int PrimaryPollRate { get; set; }
        int PriorityPollRate { get; set; }
        Protocol Protocol { get; set; }
        int SecondaryPollRate { get; set; }
        string SnmpCommunityName { get; set; }
        string SSHHostKey { get; set; }
        int SSHPort { get; set; }
        int TertiaryPollRate { get; set; }
        int MaxVbsPerPdu { get; set; }
        TimeSpan BackupPreventPeriod { get; set; }
        int FilteredCommBad { get; set; }
        int FilteredCommMarginal { get; set;  }
        int FilteredCommWeightingFactor { get; set; }
        TimeSpan AllowedTimeDrift { get; set; }

        CommAddress ToCommAddress();
    }
}
