// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Messaging.proto
{
    public class ConfigRequestProto : ConfigResponseBase
    {
        public Configuration Configuration { get; set; }
    }
}
