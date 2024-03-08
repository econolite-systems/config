// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    interface IDmsConfig : IBaseDeviceConfig
    {
        DmsType DeviceSignType { get; set; }

        /// <summary>
        /// Message memory type to use for blanking the sign
        /// </summary>
        MessageMemoryType BlankType { get; set; }

        /// <summary>
        /// Message memory index to use for blanking the sign
        /// </summary>
        ushort BlankIndex { get; set; }

        /// <summary>
        /// CRC value to use when blanking the sign
        /// </summary>
        ushort BlankCRC { get; set; }

        /// <summary>
        /// Message memory index to use for Quick Messages
        /// </summary>
        ushort QuickMessageIndex { get; set; }
    }
}
