// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System.Collections.Generic;

namespace Econolite.Ode.Config.Devices
{
    public interface ISignalConfig : IBaseDeviceConfig
    {
        Dictionary<byte, Detector> Detectors { get; }
        SignalType DeviceSignalType { get; set; }
        byte[] DynamicDetectorReferences { get; set; }
        int[] DynObjDefIds { get; set; }
        bool IsHighResCtrlEnabled { get; set; }
        ulong MSGOverlaps { get; set; }
        ulong MSGPhases { get; set; }
        Dictionary<byte, Detector> SamplingDetectors { get; }
        ulong SSGOverlaps { get; set; }
        ulong SSGPhases { get; set; }
        int VolumeOccupancyPeriod { get; set; }
        bool DiscoverDynamicObjects { get; set; }
        bool DetectorFaultPolling { get; set; }
        bool AdaptivePolling { get; set; }
    }
}
