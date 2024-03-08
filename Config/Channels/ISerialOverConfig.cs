// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
namespace Econolite.Ode.Config.Channels
{
    public interface ISerialOverConfig
    {

        /// <summary>
        /// Gets or sets the IP Address of the channel.
        /// </summary>
        string DestIp { get; set; }

        /// <summary>
        /// Gets or sets the port of the channel.
        /// </summary>
        int DestPort { get; set; }
    }
}
