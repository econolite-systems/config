// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Messaging.Source
{
    public class DeviceManagerConfigResponseSourceOptions
    {
        // Note this should include the tenant id in a multiple tenant environment
        public string DefaultChannel { get; set; } = "configresponse";
    }
}
