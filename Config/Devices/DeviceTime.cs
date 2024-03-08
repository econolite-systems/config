// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;

namespace Econolite.Ode.Config.Devices
{
    public static class DeviceTime
    {
        /// <summary>
        /// This constant is only used in this file and in the DM for managing setting and getting time
        /// from NTCIP devices. All other elements that desire to have the Unix Epoch should use
        /// DateTime.UnixEpoch instead.
        /// </summary>
        public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static uint EpochSecondsUint(DeviceTimeFormat timeFormat)
        {
            uint epochSecondsAsUnsignedInt = 0;

            // This would round, but will change behavior of current implementation. -- PGC
            //epochSecondsAsUnsignedInt = (uint)Convert.ToInt32(EpochSecondsDouble(timeFormat));

            // current refactored code does this... no rounding.
            epochSecondsAsUnsignedInt = (uint)EpochSecondsDouble(timeFormat);

            return epochSecondsAsUnsignedInt;
        }

        public static int EpochSecondsInt(DeviceTimeFormat timeFormat)
        {
            int epochSecondsAsInt = 0;

            // This would round, but will change behavior of current implementation.  -- PGC
            //epochSecondsAsInt = Convert.ToInt32(EpochSecondsDouble(timeFormat));

            epochSecondsAsInt = (int)EpochSecondsDouble(timeFormat);

            return epochSecondsAsInt;
        }

        //public static ushort EpochSecondsUshort(TimeFormat timeFormat)
        //{
        //    ushort epochSecondsAsUnsignedShort = 0;

        //    // This would round, but will change behavior of current implementation. -- PGC
        //    //epochSecondsAsUnsignedInt = (uint)Convert.ToInt32(EpochSecondsDouble(timeFormat));

        //    // current refactored code does this... no rounding.
        //    epochSecondsAsUnsignedShort = (ushort)EpochSecondsDouble(timeFormat);

        //    return epochSecondsAsUnsignedShort;
        //}

        private static double EpochSecondsDouble(DeviceTimeFormat timeFormat)
        {
            double epochSeconds = 0.0;

            TimeSpan unixToNow;

            if (timeFormat == DeviceTimeFormat.TimeLocal)
            {
                // Local time format
                unixToNow = DateTime.Now - UNIX_EPOCH;
            }
            else
            {
                // UTC time format
                // I assume here, like previous code that we'll treat TimeLocal, TimeACT also as UTC. See TimeFormat Enum. -- PGC
                unixToNow = DateTime.UtcNow - UNIX_EPOCH;
            }

            epochSeconds = unixToNow.TotalSeconds;

            return epochSeconds;
        }
    }
}
