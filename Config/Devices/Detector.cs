// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;

namespace Econolite.Ode.Config.Devices
{
    public class Detector
    {
        #region Properties

        public Guid DetectorId { get; set; }
        public byte Reference { get; set; }
        public DetectorType DetectorType { get; set; }

        #endregion
    }
}
