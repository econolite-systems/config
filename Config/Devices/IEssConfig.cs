// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    public interface IEssConfig : IBaseDeviceConfig
    {
        EssType DeviceEssType { get; set; }
    }
}
