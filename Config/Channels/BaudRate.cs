// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Channels
{
    // These types different from the values found in Centracs Econolite.Genesis.Common.CommApps.BaudRate
    public enum BaudRate : int
    {
        Unknown = 0,
        br_1200 = 1200,
        br_2400 = 2400,
        br_4800 = 4800,
        br_9600 = 9600,
        br_19200 = 19200,
        br_38400 = 38400,
        br_57600 = 57600,
        br_115200 = 115200,
        br_128000 = 128000,
        br_153200 = 153200
    }
}
