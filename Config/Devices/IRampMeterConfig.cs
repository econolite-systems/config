// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    public interface IRampMeterConfig : IBaseDeviceConfig
    {
        RampMeterType DeviceRampMeterType { get; set; }
    }
}
