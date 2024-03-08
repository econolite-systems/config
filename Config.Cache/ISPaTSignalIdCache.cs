// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Cache
{
    public interface ISPaTSignalIdCache
    {
        Task PutSignalMapsAsync(Guid tenantId, Dictionary<int, Guid> signalMapping, CancellationToken cancellationToken = default);
        Task<Guid> GetSignalIdAsync(Guid tenantId, int signalId, CancellationToken cancellationToken = default);
    }
}
