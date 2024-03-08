// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Sink
{
    public interface IDeviceManagerConfigResponseSink
    {
        Task SinkAsync(Guid tenantId, ConfigResponseBase configResponse, CancellationToken cancellationToken);
    }
}
