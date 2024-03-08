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
    public enum Handshake
    {
        //
        // Summary:
        //     No control is used for the handshake.
        None = 0,
        //
        // Summary:
        //     The XON/XOFF software control protocol is used. The XOFF control is sent to stop
        //     the transmission of data. The XON control is sent to resume the transmission.
        //     These software controls are used instead of Request to Send (RTS) and Clear to
        //     Send (CTS) hardware controls.
        XOnXOff = 1,
        //
        // Summary:
        //     Request-to-Send (RTS) hardware flow control is used. RTS signals that data is
        //     available for transmission. If the input buffer becomes full, the RTS line will
        //     be set to false. The RTS line will be set to true when more room becomes available
        //     in the input buffer.
        RequestToSend = 2,
        //
        // Summary:
        //     Both the Request-to-Send (RTS) hardware control and the XON/XOFF software controls
        //     are used.
        RequestToSendXOnXOff = 3
    }
}
