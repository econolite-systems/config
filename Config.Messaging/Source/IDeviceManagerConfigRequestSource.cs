// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Source
{
    public interface IDeviceManagerConfigRequestSource
    {
        Task ConsumeOn(Func<(Guid TenantId, int DeviceManagerId, int RequestVersion), Task> consumeFunc, CancellationToken cancellationToken);
    }
}
