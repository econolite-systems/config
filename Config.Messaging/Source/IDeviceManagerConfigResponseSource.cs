// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Source
{
    public interface IDeviceManagerConfigResponseSource
    {
        Task ConsumeOnAsync(int myId, Func<(Guid TenantId, ConfigResponse ConfigResponse), Task> consumeFunc , CancellationToken cancellationToken);
    }
}
