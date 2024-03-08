// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using Econolite.Ode.Messaging.Elements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Econolite.Ode.Config.Messaging.Extensions
{
    public static class ChannelDefined
    {
        public static IBaseChannelConfig[] ToChannels(this JsonArray json)
        {
            var result = new List<IBaseChannelConfig>(json.Count);
            foreach (var channel in json)
            {
                var channeltype = Enum.Parse<ChannelType>(channel["ChannelType"]?.ToString() ?? "-1");
                var t = channel.ToJsonString();
                switch (channeltype)
                {
                    case ChannelType.Serial:
                        break;
                    case ChannelType.Udp:
                        result.Add(JsonSerializer.Deserialize<UdpConfig>(channel.ToJsonString(), JsonPayloadSerializerOptions.Options));
                        break;
                    case ChannelType.SerialOverUdp:
                        result.Add(JsonSerializer.Deserialize<SerialOverUdpConfig>(channel.ToJsonString(), JsonPayloadSerializerOptions.Options));
                        break;
                    case ChannelType.SharedUdp:
                        result.Add(JsonSerializer.Deserialize<SharedUdpConfig>(channel.ToJsonString(), JsonPayloadSerializerOptions.Options));
                        break;
                    case ChannelType.Tcp:
                        result.Add(JsonSerializer.Deserialize<TcpConfig>(channel.ToJsonString(), JsonPayloadSerializerOptions.Options));
                        break;
                    case ChannelType.SerialOverTcp:
                        break;
                    case ChannelType.SharedTcp:
                        break;
                    case ChannelType.Tls:
                        result.Add(JsonSerializer.Deserialize<TlsConfig>(channel.ToJsonString(), JsonPayloadSerializerOptions.Options));
                        break;
                    default:
                        Debug.Assert(false, "New type of channel that can't be extracted and will be ignored");
                        break;
                }
            }

            return result.ToArray();
        }
    }
}
