using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.IO.Ports;

namespace UART
{
    public class Program
    {
        //===========================MOTION SENSOR=========================
        //static InterruptPort port = new InterruptPort(Pins.GPIO_PIN_D1, false, ResistorModes.Disabled, InterruptModes.InterruptEdgeLow);
        //static bool MovementDetected = false;
        //===========================UART==================================
        private static readonly object lockObject = new object();
        //===========================ULTRASONIC SENSOR=====================
        private static SecretLabs.NETMF.Hardware.AnalogInput sensor = new SecretLabs.NETMF.Hardware.AnalogInput(Pins.GPIO_PIN_A1);
        //===========================UART==================================
        static SerialPort spUART = new SerialPort(SerialPorts.COM2, 9600, Parity.None, 8, StopBits.One);
        static OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

        //===========================MOTION SENSOR=========================
        //static void motion_OnInterrupt(uint data1, uint data2, DateTime time)
        //{
        //    port.DisableInterrupt();
        //    Debug.Print("Found movement ");
        //    MovementDetected = true;
        //}

        //UART
        private static void sendDataUsingCOMPort(string _string)
        {
            lock (lockObject)
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(_string + "\n");
                spUART.Write(data, 0, data.Length);
                spUART.Flush();
            }
        }

        //UART
        static void receivedDataUsingCOMPort(object sender, SerialDataReceivedEventArgs e)
        {
            SecretLabs.NETMF.Hardware.PWM speaker = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D5);
            speaker.SetDutyCycle(50);
            uint duration1 = 5000, duration2 = 5000;
            try
            {
                if (spUART.BytesToRead > 0)
                {
                    byte[] buffer = new byte[spUART.BytesToRead];
                    spUART.Read(buffer, 0, buffer.Length);
                    char[] cReceived = System.Text.Encoding.UTF8.GetChars(buffer, 0, buffer.Length);

                    string strReceived = new string(cReceived);
                    Debug.Print("command string received " + strReceived);

                    if (cReceived[0] == 'N')
                    {
                        led.Write(true);
                    }
                    else if (cReceived[0] == 'F')
                    {
                        led.Write(false);
                    }
                    //MOTION SENSOR - PIEZO BUZZER TURN ON
                    else if (cReceived[0] == 'A')
                    {
                        Debug.Print("Alarm sounding");
                        for (int i = 0; i < 3; i++)
                        {
                            speaker.SetPulse(duration1 * 2, duration1);
                            Thread.Sleep(300);
                            speaker.SetPulse(duration2 * 2, duration2);
                            Thread.Sleep(300);
                            speaker.SetDutyCycle(0);
                        }
                    }
                    //PIEZO BUZZER TURN OFF
                    else if (cReceived[0] == 'B')
                    {
                        Debug.Print("Turned off alarm");
                        speaker.SetDutyCycle(0);
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.Print("exception " + ex.Message.ToString());
            }
        }

        //RFID
        //private static idReader _idReader;

        //private static void StartRFID()
        //{
        //    _idReader = new idReader(SerialPorts.COM1);
        //    _idReader.RfidEvent += new idReader.RfidEventDelegate(_idReader_RfidEvent);
        //}
        //RFID
        //static void _idReader_RfidEvent(object sender, idReader.RfidEventArgs e)
        //{
        //    Debug.Print("Card scanned: " + e.RFID);
        //    sendDataUsingCOMPort("CARD=" + e.RFID);
        //}

        public static void Main()
        {
            //MOTION SENSOR
            //port.OnInterrupt += new NativeEventHandler(motion_OnInterrupt);
            //port.EnableInterrupt();

            //UART
            InputPort button = new InputPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled);
            bool ButtonState = false;
            spUART.DataReceived += new SerialDataReceivedEventHandler(receivedDataUsingCOMPort);

            spUART.Open();

            //RFID
            //StartRFID();

            //TEMPERATURE SENSOR
            //SecretLabs.NETMF.Hardware.AnalogInput temp = new SecretLabs.NETMF.Hardware.AnalogInput(Pins.GPIO_PIN_A0);
            //const double EFSR = 3.3;
            //const int N = 1023;
            int adcValue;
            //double Q = 0.0;
            //double sensorVoltage = 0.0, tempC = 0.0;
            //ULTRASONIC SENSOR
            double distanceInCm = 0.0;
            //double Kelvin;
            //double Fahrenheit;
            //double Newton;

            while (true)
            {
                //MOTION SENSOR
                //if (MovementDetected == true)
                //{
                //    Debug.Print("Motion detected! Alarm sounding");
                //    sendDataUsingCOMPort("MOTION STATUS=" + "MOTION DETECTED!");
                //    Thread.Sleep(5000);
                //}
                ButtonState = button.Read();
                if (ButtonState == true)
                {
                    sendDataUsingCOMPort("PUSH BUTTON STATUS=" + "Push button pressed, activating Camera");
                }
                adcValue = sensor.Read();
                //Q = EFSR / N;

                //sensorVoltage = adcValue * Q;
                //tempC = 100 * (sensorVoltage - 0.5);
                //Kelvin = tempC + 273;
                //Fahrenheit = tempC * 18 / 10 + 32;
                //Newton = tempC * 33 / 100;
                distanceInCm = adcValue * 0.5 * 2.5;

                string UltrasonicStatus;
                Debug.Print("Distance: " + distanceInCm.ToString("N2"));
                Thread.Sleep(2000);
                sendDataUsingCOMPort("DISTANCE IN CM=" + distanceInCm.ToString("N2"));
                Thread.Sleep(3000);

                if (distanceInCm < 30)
                {
                    UltrasonicStatus = "You turned the lights and switches ON";
                }

                if (distanceInCm > 30 && distanceInCm < 50)
                {
                    UltrasonicStatus = "Move your hand a little closer to turn lights and switches ON";
                }
                if (distanceInCm > 51)
                {
                    UltrasonicStatus = "Unreachable distance, lights and switches OFF";
                }

            }
        }
    }
}

 

