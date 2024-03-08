// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Messaging
{
    public class ConfigResponse : ConfigResponseBase
    {
        public IBaseChannelConfig[] Channels { get; set; }
        public IBaseDeviceConfig[] Devices { get; set; }
    }
}
