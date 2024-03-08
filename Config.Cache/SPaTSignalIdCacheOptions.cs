// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;

namespace Econolite.Ode.Config.Cache
{
    public class SPaTSignalIdCacheOptions
    {
        public TimeSpan RefreshFromCache { get; set; } = TimeSpan.FromMinutes(5);
    }
}
