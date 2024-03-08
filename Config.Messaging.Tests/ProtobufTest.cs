// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using AutoBogus;
using Econolite.Ode.Config.Messaging.Extensions;
using Econolite.Ode.Config.Messaging.proto;
using System.Reflection;

namespace Config.Messaging.Tests
{
    public class ProtobufTest
    {
        public class CustomBinder : AutoBinder
        {
            public override TType CreateInstance<TType>(AutoGenerateContext context)
            {
                if (typeof(TType) == typeof(Uuid))
                    return (TType)MakeUuid(); //wish it was this easy
                return base.CreateInstance<TType>(context);
            }

            public override void PopulateInstance<TType>(object instance, AutoGenerateContext context, IEnumerable<MemberInfo>? members = null)
            {
                if (typeof(TType) == typeof(Uuid))
                    return; //already populated from create instance.
                base.PopulateInstance<TType>(instance, context, members);
            }

            public static object MakeUuid() => //the life, ay?
               new AutoFaker<Uuid>()
                  .RuleFor(x => x.Value, f => new Guid(f.Random.Bytes(16)).ToString())
                  .Generate();
        }

        [Fact]
        public void TestRoundTripAndExtensions()
        {
            // Create a config
            var tobj = new AutoFaker<Configuration>(new CustomBinder())
                //.Configure(_ => _.WithOverride(new SignalOverride()))
                .UseSeed(42)
                .Generate();
            var built = new ConfigRequestProto
            {
                Configuration = tobj,
                DeviceManagerId = tobj.DeviceManagerId,
            };

            var configresponse = built.ToConfigResponse();
            var roundtrip = configresponse.ToProtobuf();
            roundtrip.Configuration.Should().BeEquivalentTo(tobj);
        }
    }
}
