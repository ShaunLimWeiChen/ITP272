using System;
using Microsoft.SPOT;
using System.IO.Ports;
using Microsoft.SPOT.Hardware;

namespace UART
{
    class idReader
    {
        #region Public Event

        public delegate void RfidEventDelegate(object sender, RfidEventArgs e);

        public event RfidEventDelegate RfidEvent;

        public class RfidEventArgs : EventArgs
        {
            private string _RFID;

            public string RFID
            {
                get { return _RFID; }
                set { _RFID = value; }
            }


        }

        private void OnRfidEvent(RfidEventArgs e)
        {
            if (RfidEvent != null)
            {
                RfidEvent(this, e);
            }
        }

        #endregion //#endregion marks the end of a #region block
        // #region is for grouping, organizing your code

        private SerialPort rfidPort; // Serial port the reader is connected on.
        private SerialDataReceivedEventHandler _serialReadEvent; // Serial event handler.        

        public idReader(string _rfidSerialPort)
        {
            // Set up the ports as necessary.
            rfidPort = new SerialPort(_rfidSerialPort, 9600, Parity.None, 8, StopBits.One);

            // Set up the event handler.
            _serialReadEvent = new SerialDataReceivedEventHandler(_rfidCardDataReceived);

            // Open the port and set an event handler to receive incoming serial data.
            rfidPort.Open();
            rfidPort.DataReceived += _serialReadEvent;
        }

        ~idReader()  //has the effect of reversing each bit
        {
            // Close the serial port.
            rfidPort.Close();

            // Detach the event handler.
            rfidPort.DataReceived -= _serialReadEvent;
        }


        private void _rfidCardDataReceived(object _cardPort, SerialDataReceivedEventArgs unused)
        {
            // Capture the port that the data was received on.
            SerialPort cardPort = (SerialPort)_cardPort;

            //String cardID = String.Empty;
            int iRFIDReadLen = cardPort.BytesToRead;

            //RFID always read in 16 bytes of data
            if (iRFIDReadLen == 16)
            {
                byte[] rawData = new byte[16]; // Incoming raw bytes from the serial connection.
                char[] idStringData = new char[10]; // ID String data.

                //Read in 16 bytes data
                cardPort.Read(rawData, 0, rawData.Length);

                // Card ID is a 10 byte ASCII data
                // It is located at byte 1 - 11 of the 16 bytes
                for (int i = 0; i < 10; i++)
                {
                    idStringData[i] = (char)rawData[i + 1];   // skip first byte                     
                }

                RfidEventArgs _args = new RfidEventArgs();
                _args.RFID = new string(idStringData);
                OnRfidEvent(_args);
            }
        }           
    }
}