// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Messaging.Extensions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Config.Messaging.Tests
{
    public class ConfigSerializationTests
    {
        [Fact]
        public void Test1()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("Config.Messaging.Tests.Config1.json");
            var config = JsonSerializer.Deserialize<JsonNode>(stream ?? Stream.Null);
            var id = config.ExtractDMId();
            id.Should().Be(55000);
            var channels = config.ExtractChannels();
            channels.Length.Should().Be(1);
            var devices = config.ExtractDevices();
            devices.Length.Should().Be(4);
        }

        [Fact]
        public void Test2()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("Config.Messaging.Tests.ConfigMobility.json");
            var config = JsonSerializer.Deserialize<JsonNode>(stream ?? Stream.Null, Econolite.Ode.Messaging.Elements.JsonPayloadSerializerOptions.Options);
            var id = config.ExtractDMId();
            id.Should().Be(1);
            var channels = config.ExtractChannels();
            channels.Length.Should().Be(1);
            var devices = config.ExtractDevices();
            devices.Length.Should().Be(1);
        }
    }
}
