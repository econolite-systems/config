// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;

namespace Econolite.Ode.Config.Devices
{
    // Simple class to be used in logging
    public class CommAddress
    {
        public CommAddress(string deviceIp, int? devicePort, int? deviceDropAddress, Protocol protocol)
        {
            DeviceIp = deviceIp;
            DevicePort = devicePort ?? 0;
            DeviceDropAddress = deviceDropAddress ?? 0;
            Protocol = protocol;
        }

        public string DeviceIp { get; }

        public int DevicePort { get; }

        public int DeviceDropAddress { get; }

        public Protocol Protocol { get; }
    }
}
