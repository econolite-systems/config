// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    // These types all have the same values as those found in Centracs Econolite.Genesis.Common.DMS.DmsMessageMemoryType
    public enum MessageMemoryType
    {
        UNKNOWN = 0,

        // any other type of memory type that is not listed within one of
        // the values below, refer to device manual;
        // Other (1), -retired

        /// <summary>
        /// Non-volatile and non-changeable;
        /// </summary>
        Permanent = 2,

        /// <summary>
        /// Non-volatile and changeable
        /// </summary>
        Changeable = 3,

        /// <summary>
        /// Volatile and changeable
        /// </summary>
        Volatile = 4,

        /// <summary>
        /// contains the information regarding the currently
        /// displayed message (basically a copy of the message table row
        /// contents of the message that was successfully activated).
        /// Only one entry in the table can have the 
        /// value of currentBuffer and the value of the dmsMessageNumber
        /// object shall be one (1). The content of the
        /// dmsMessageMultiString object shall be the currently displayed
        /// message (including a scheduled message), not the content of a
        /// failed message activation attempt;
        /// </summary>
        CurrentBuffer = 5,

        /// <summary>
        /// this entry contains information regarding the currently
        /// scheduled message as determined by the time-base scheduler (if
        /// present). Only one entry in the table can have the value of
        /// 'schedule' and the value of dmsMessageNumber for this entry
        /// shall be 1. Displaying a message through this table row shall set
        /// the dmsMsgSourceMode object value to 'timebasedScheduler'.
        /// When no message is currently active based upon the schedule
        /// or if the schedule currently does not point to any message within
        /// the message table, the schedule entry shall contain a copy of
        /// dmsMessageMemoryType 7 (blank) with a dmsMessageNumber value of 1.
        /// </summary>
        Schedule = 6,

        /// <summary>
        /// there shall be 255 (message numbers 1 through 255)
        /// pre-defined, static rows with this message type. These rows are
        /// defined so that message codes (e.g., objects with SYNTAX of
        /// either MessageIDCode or MessageActivationCode) can blank the
        /// sign at a stated run-time priority. The run-time priority of the blank
        /// message is equal to the message number (e.g., blank message
        /// number 1 has a run time priority of 1 and so on). The
        /// dmsMessageCRC for all messages of this type shall be 0x0000 and
        /// the dmsMessageMultiString shall be an OCTET STRING with a length of
        /// zero (0). The activation priority shall be determined from the
        /// activation priority of the MessageActivationCode.
        /// </summary>
        Blank = 7,
    }
}
