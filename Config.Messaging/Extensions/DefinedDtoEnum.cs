// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Channels;
using Econolite.Ode.Config.Devices;
using System;

namespace Econolite.Ode.Config.Messaging.Extensions
{
    public static class DefinedDtoEnum
    {
        public static proto.Uuid ToProtobuf(this Guid guid) => new proto.Uuid
        {
            Value = guid.ToString(),
        };

        public static Guid ToConfigResponse(this proto.Uuid uuid) => Guid.Parse(uuid.Value);

        public static proto.TimeFormat ToProtobuf(this DeviceTimeFormat timeFormat) => timeFormat switch
        {
            DeviceTimeFormat.TimeLocal => proto.TimeFormat.TimeLocal,
            DeviceTimeFormat.TimeUTC => proto.TimeFormat.TimeUTC,
            _ => proto.TimeFormat.TimeDefault,
        };

        public static DeviceTimeFormat ToConfigResponse(this proto.TimeFormat timeFormat) => timeFormat switch
        {
            proto.TimeFormat.TimeLocal => DeviceTimeFormat.TimeLocal,
            proto.TimeFormat.TimeUTC => DeviceTimeFormat.TimeUTC,
            _ => DeviceTimeFormat.TimeDefault,
        };

        public static proto.SignalType ToProtobuf(this SignalType type) => type switch
        {
            SignalType.ASC3 => proto.SignalType.Asc3,
            SignalType.ASC3Cobalt => proto.SignalType.Asc3,
            SignalType.Eos => proto.SignalType.Eos,
            SignalType.EosCobalt => proto.SignalType.Eos,
            SignalType.Eagle => proto.SignalType.Eagle,
            SignalType.MaxTime => proto.SignalType.MaxTime,
            SignalType.TrafficWareCommander => proto.SignalType.TrafficWareCommander,
            SignalType.D4 => proto.SignalType.D4,
            SignalType.AB3418 => proto.SignalType.Ab3418,
            SignalType.AB3418E => proto.SignalType.Ab3418e,
            _ => proto.SignalType.Ntcip,
        };

        public static SignalType ToConfigResponse(this proto.SignalType type) => type switch
        {
            proto.SignalType.Asc3 => SignalType.ASC3,
            proto.SignalType.Eos => SignalType.Eos,
            proto.SignalType.Eagle => SignalType.Eagle,
            proto.SignalType.MaxTime => SignalType.MaxTime,
            proto.SignalType.TrafficWareCommander => SignalType.TrafficWareCommander,
            proto.SignalType.D4 => SignalType.D4,
            proto.SignalType.Ab3418 => SignalType.AB3418,
            proto.SignalType.Ab3418e => SignalType.AB3418E,
            _ => SignalType.GenericNtcip,
        };

        public static proto.CommunicationMode ToProtobuf(this CommMode value) => value switch
        {
            CommMode.Offline => proto.CommunicationMode.OffLine,
            CommMode.Online => proto.CommunicationMode.OnLine,
            CommMode.Standby => proto.CommunicationMode.StandBy,
            _ => proto.CommunicationMode.OnLine,
        };

        public static CommMode ToConfigResponse(this proto.CommunicationMode value) => value switch
        {
            proto.CommunicationMode.OffLine => CommMode.Offline,
            proto.CommunicationMode.OnLine => CommMode.Online,
            proto.CommunicationMode.StandBy => CommMode.Standby,
            _ => CommMode.Online,
        };

        public static proto.Protocol ToProtobuf(this Protocol value) => value switch
        {
            Protocol.NTCIP => proto.Protocol.Ntcip,
            _ => proto.Protocol.Ntcip,
        };

        public static Protocol ToConfigResponse(this proto.Protocol value) => value switch
        {
            proto.Protocol.Ntcip => Protocol.NTCIP,
            _ => Protocol.NTCIP,
        };
    }
}
