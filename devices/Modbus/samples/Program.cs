using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.Hardware.Esp32;

using Iot.Device.Modbus.Client;
using Iot.Device.Modbus.Server;

namespace Iot.Device.Modbus.Samples
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");            

            // SerialPort COM2
            Configuration.SetPinFunction(16, DeviceFunction.COM2_RX);
            Configuration.SetPinFunction(17, DeviceFunction.COM2_TX);
            Configuration.SetPinFunction(18, DeviceFunction.COM2_RTS);

            // SerialPort COM3
            Configuration.SetPinFunction(25, DeviceFunction.COM3_RX);
            Configuration.SetPinFunction(26, DeviceFunction.COM3_TX);
            Configuration.SetPinFunction(27, DeviceFunction.COM3_RTS);

            // Modbus Server
            var server = new ModbusServer(new Device(1), "COM2");
            server.ReadTimeout = server.WriteTimeout = 2000;
            server.StartListening();

            // Modbus Client
            var client = new ModbusClient("COM3");
            client.ReadTimeout = client.WriteTimeout = 2000;

            client.WriteMultipleRegisters(2, 0x5, new ushort[] { 3, 5, 2, 3 });
            client.Raw(2, FunctionCode.Diagnostics, new byte[] { 0x01, 0x01, 0x01, 0x01 });

            //reading value with more than a byte length and cnverting it bach to original value
            var result = client.ReadHoldingRegisters(2, 200, 4);
            double sensor = Utilities.DecodeDouble(result);

            var data1 = client.ReadHoldingRegisters(2, 0x7, 4);
            var data2 = client.ReadCoils(2, 0x23, 2);

            Thread.Sleep(Timeout.Infinite);
        }
    }

    class Device : ModbusDevice
    {
        public Device(byte id = 1) : base(id)
        { 
        }

        /// <summary>
        /// Read Coil
        /// </summary>
        /// <param name="address">Register address</param>
        /// <param name="value">Output register values</param>
        /// <returns>True: address is readable; False: address is invalid</returns>
        protected override bool TryReadCoil(ushort address, out bool value)
        {
            // Your code is here...
            switch (address)
            {
                case 100:
                    value = false;  // Gets the switch status
                    break;
                case 101:
                    value = true;  // Gets the switch status
                    break;
                default:
                    value = false;
                    return false;
            }
            return true;
        }

        protected override bool TryReadDiscreteInput(ushort address, out bool value)
        {
            // Similar to the code above...
            throw new NotImplementedException();
        }

        protected override bool TryReadHoldingRegister(
            ushort address,
            out short value)
        {
            // Similar to the code above...
            switch (address)
            {
                case 200://sensor readout
                    double sensorReadout1 = ReadSensor();                   
                    value = Utilities.EncodeDouble(sensorReadout1)[0];
                    break;
                case 201://sensor readout
                    double sensorReadout2 = ReadSensor();   
                    value = Utilities.EncodeDouble(sensorReadout2)[1];
                    break;
                case 202://sensor readout
                    double sensorReadout3 = ReadSensor();   
                    value = Utilities.EncodeDouble(sensorReadout3)[2];
                    break;
                case 203://sensor readout
                    double sensorReadout4 = ReadSensor();   
                    value = Utilities.EncodeDouble(sensorReadout4)[3];
                    break;
                default:
                    value = 0;
                    return false;
            }
            return true;
        }

        protected override bool TryReadInputRegister(ushort address, out short value)
        {
            // Similar to the code above...
            throw new NotImplementedException();
        }

        protected override bool TryWriteCoil(ushort address, bool value)
        {
            // Similar to the code above...
            throw new NotImplementedException();
        }

        protected override bool TryWriteHoldingRegister(ushort address, short value)
        {
            // Similar to the code above...
            throw new NotImplementedException();
        }
    }

    //utility class for encoding/decoding ushort
    public static Utilities
    {
        private const int DoubleBytes = 8;
        private const int DoubleShorts = DoubleBytes / sizeof(short);
        
        public static short[] EncodeDouble(double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            short[] result = new short[DoubleShorts];
        
            for (int i = 0; i < DoubleShorts; i++)
            {
                result[i] = (short)(bytes[i * 2] << 8 | bytes[i * 2 + 1]);
            }
        
            return result;
        }
        
        public static double DecodeDouble(short[] encodedDouble)
        {
            if (encodedDouble == null || encodedDouble.Length != DoubleShorts)
            {
                throw new ArgumentException("Invalid encoded double format.");
            }
        
            byte[] bytes = new byte[DoubleBytes];
        
            for (int i = 0; i < DoubleShorts; i++)
            {
                bytes[i * 2] = (byte)(encodedDouble[i] >> 8);
                bytes[i * 2 + 1] = (byte)(encodedDouble[i] & 0xFF);
            }
        
            return BitConverter.ToDouble(bytes);
        }
    }
}
