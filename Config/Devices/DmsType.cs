// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Devices
{
    // These types all have the same values as those found in Centracs Econolite.Genesis.Common.DMS.DmsSignType
    public enum DmsType
    {
        /// <summary> Not used in 1203. </summary>
        Unknown = 0,

        /// <summary> Device not specified </summary>
        Other,

        /// <summary> Blank-Out Sign </summary>
        BOS = 2,

        /// <summary> Changeable Message Sign </summary>
        CMS = 3,

        /// <summary> Device is a Variable Message Sign with character matrix </summary>
        VmsChar = 4,

        /// <summary> Device is a Variable Message Sign with line matrix </summary>
        VmsLine = 5,

        /// <summary> Device is a Variable Message Sign with full matrix </summary>
        VmsFull = 6,

        /// <summary> Portable, device not specified </summary>
        PortableOther = 129,

        /// <summary> Portable, Blank-Out Sign </summary>
        PortableBOS = 130,

        /// <summary> Portable, Changeable Message Sign </summary>
        PortableCMS = 131,

        /// <summary> Portable, Device is a Variable Message Sign with character matrix </summary>
        PortableVMSChar = 132,

        /// <summary> Portable, Device is a Variable Message Sign with line matrix </summary>
        PortableVMSLine = 133,

        /// <summary> Portable, Device is a Variable Message Sign with full matrix </summary>
        PortableVMSFull = 134,
    }
}
