// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Channels
{
    // These types all have the same values as those found in .netframework System.IO.Ports
    // They are replicated as we are targeting .net Standard with the option of running in
    // .net core where System.IO.Ports does not exist.
    //
    // Just how we will deal with the lack of serial ports on a non window platform is
    // something we will have to deal down stream. As it is we will have to have a serial
    // port implementation passed into this libary on the windows platform.
    public enum StopBits
    {
        //
        // Summary:
        //     No stop bits are used. This value is not supported by the System.IO.Ports.SerialPort.StopBits
        //     property.
        None = 0,
        //
        // Summary:
        //     One stop bit is used.
        One = 1,
        //
        // Summary:
        //     Two stop bits are used.
        Two = 2,
        //
        // Summary:
        //     1.5 stop bits are used.
        OnePointFive = 3
    }
}
