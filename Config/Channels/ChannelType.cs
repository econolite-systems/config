// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Channels
{
    // These types different from the values found in Centracs Econolite.Genesis.Common.CommApps.ChannelType
    public enum ChannelType
    {
        Serial,
        Udp,
        SerialOverUdp,
        SharedUdp,
        Tcp,
        SerialOverTcp,
        SharedTcp,
        Tls,
    }
}
