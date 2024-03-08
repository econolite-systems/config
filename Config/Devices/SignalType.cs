// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    public enum SignalType
    {
        ASC2 = 0,

        ASC3 = 1,
        Oasis = 2,
        W4 = 3,
        Eagle = 4,

        /// <summary>
        /// Generic Ntcip controller
        /// </summary>
        GenericNtcip = 5,

        /// <summary>
        /// Tek Chile controller type.
        /// </summary>
        TekTs = 6,

        /// <summary>
        /// Forth Dimension's controller.
        /// </summary>
        D4 = 8,

        ASC3Cobalt = 9,
        Eos = 10,
        /// <summary>
        /// MaxTime is the Intelight controller
        /// </summary>
        MaxTime = 11,

        EosCobalt = 12,
        McCainOnmiEx = 13,
        TrafficWareCommander = 14,
        SPAT = 15,

        AB3418 = 100,
        AB3418E = 101,
    }
}
