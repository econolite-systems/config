// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using System;
using System.Threading.Tasks;

namespace Econolite.Ode.Config.Messaging.Sink
{
    public interface IDeviceManagerConfigRequestSink
    {
        Task SinkAsync(Guid tenantId, int deviceManagerId);
    }
}
