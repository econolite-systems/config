// SPDX-License-Identifier: MIT
// Copyright: 2023 Econolite Systems, Inc.
using Econolite.Ode.Config.Devices;

namespace Econolite.Ode.Config.Channels
{
    public class SerialConfig : BaseChannelConfig
    {
        public SerialConfig(int id, string name, Protocol protocol, int retries, int pollRetries, int innerByteDelay, int innerDeviceDelay, bool innerChannelDelay, int commRequestTimeout, int byteRxTimeout, int maxExpectedPacketsize, int pollErrorThreshold, int failedPollRate, int primaryPollRate, int secondaryPollRate, int priorityPollRate, int teriaryPollRate, string broadcastIpAddress, DeviceTimeFormat timeFormat, BaudRate baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake flowControl, int ctsOnDelay, int rtsOnDelay, int[] commPorts)
            : base(id, name, protocol, retries, pollRetries, innerByteDelay, innerDeviceDelay, innerChannelDelay, commRequestTimeout, byteRxTimeout, maxExpectedPacketsize, pollErrorThreshold, failedPollRate, primaryPollRate, secondaryPollRate, priorityPollRate, teriaryPollRate, broadcastIpAddress, timeFormat)
        {
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
            FlowControl = flowControl;
            CtsOnDelay = ctsOnDelay;
            RtsOnDelay = rtsOnDelay;
            CommPorts = commPorts;
        }

        // Empty constructor for serialization
        protected SerialConfig()
        {
        }

        public override ChannelType ChannelType => ChannelType.Serial;
        #region Properties

        /// <summary>
        /// Gets or sets the communication speed of the channel.
        /// </summary>
        public BaudRate BaudRate { get; set; }

        public Parity Parity { get; set; }

        public int DataBits { get; set; }

        public StopBits StopBits { get; set; }

        public Handshake FlowControl { get; set; }

        public int CtsOnDelay { get; set; }

        public int RtsOnDelay { get; set; }

        public int[] CommPorts { get; set; }
        #endregion

    }
}
