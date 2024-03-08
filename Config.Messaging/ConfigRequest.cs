// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Messaging
{
    public class ConfigRequest
    {
        public int DeviceManagerId { get; set; }
        public int RequestVersion { get; set; } = 0;
    }
}
