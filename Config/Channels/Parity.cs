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
    public enum Parity
    {
        //
        // Summary:
        //     No parity check occurs.
        None = 0,
        //
        // Summary:
        //     Sets the parity bit so that the count of bits set is an odd number.
        Odd = 1,
        //
        // Summary:
        //     Sets the parity bit so that the count of bits set is an even number.
        Even = 2,
        //
        // Summary:
        //     Leaves the parity bit set to 1.
        Mark = 3,
        //
        // Summary:
        //     Leaves the parity bit set to 0.
        Space = 4
    }
}
