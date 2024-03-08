// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    // These types all have the same values as those found in Centracs Econolite.Genesis.Common.DeviceMode
    public enum CommMode
    {
        /// <summary>
        /// Full communications enabled.
        /// </summary>
        Online,

        /// <summary>
        /// Stop communications.
        /// </summary>
        Offline,

        /// <summary>
        /// No device polling, but still able to send commands.
        /// </summary>
        Standby,
    }
}
