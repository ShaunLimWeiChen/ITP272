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
        static InterruptPort port = new InterruptPort(Pins.GPIO_PIN_D1, false, ResistorModes.Disabled, InterruptModes.InterruptEdgeLow);
        static bool MovementDetected = false;
        static SecretLabs.NETMF.Hardware.PWM speaker = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D5);
        //===========================UART==================================
        private static readonly object lockObject = new object();
        //===========================ULTRASONIC SENSOR=====================
        private static SecretLabs.NETMF.Hardware.AnalogInput sensor = new SecretLabs.NETMF.Hardware.AnalogInput(Pins.GPIO_PIN_A1);
        //===========================UART==================================
        static SerialPort spUART = new SerialPort(SerialPorts.COM2, 9600, Parity.None, 8, StopBits.One);
        static OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

        //===========================MOTION SENSOR=========================
        static void motion_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            try
            {
                //port.EnableInterrupt();
                port.DisableInterrupt();
                DateTime startTime = DateTime.Now;
                // Some execution process
                DateTime endTime = DateTime.Now;
                TimeSpan totalTimeTaken = endTime.Subtract(startTime);
                Debug.Print("Motion detected");
                speaker.SetDutyCycle(50);
                uint duration1 = 1000, duration2 = 800;
                Debug.Print("Alarm sounding");
                for (int i = 0; i < 2; i++)
                {
                    speaker.SetPulse(duration1 * 2, duration1);
                    Thread.Sleep(200);
                    speaker.SetPulse(duration2 * 2, duration2);
                    Thread.Sleep(200);
                    speaker.SetDutyCycle(0);
                }
                sendDataUsingCOMPort("MOTION=" + "MOTION DETECTED FOR " + totalTimeTaken + "s ");
                //spUART.Flush();
                //Thread.Sleep(5000);
                //uint duration1 = 1000, duration2 = 1000;
                //speaker.SetPulse(duration1 * 2, duration1);
                //speaker.SetPulse(duration2 * 2, duration2);
                //Thread.Sleep(250);
                //speaker.SetDutyCycle(0);
                MovementDetected = true;
                //OutputPort redLED = new OutputPort(Pins.GPIO_PIN_D9, false);
                //for (int i = 0; i < 3; i++)
                // {
                //   redLED.Write(true);
                //   Thread.Sleep(300);
                //   redLED.Write(false);
                //}
                Thread.Sleep(5000);
                port.EnableInterrupt();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

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
                        else if (cReceived[0] == 'Z')
                        {
                            MovementDetected = false;
                        }
                        else if (cReceived[0] == 'Y')
                        {
                            MovementDetected = true;
                        }
                    }
                }

                catch (Exception ex)
                {
                    Debug.Print("exception " + ex.Message.ToString());
                }
            }
        //RFID
        private static idReader _idReader;

        private static void StartRFID()
        {
            _idReader = new idReader(SerialPorts.COM3);
            _idReader.RfidEvent += new idReader.RfidEventDelegate(_idReader_RfidEvent);
        }
        //RFID
        static void _idReader_RfidEvent(object sender, idReader.RfidEventArgs e)
        {
            Debug.Print("Card scanned: " + e.RFID);

            sendDataUsingCOMPort("CARD=" + e.RFID);
        }

        public static void Main()
        {
            InputPort button = new InputPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled);
            bool ButtonState = false;

            //UART
            spUART.DataReceived += new SerialDataReceivedEventHandler(receivedDataUsingCOMPort);

            spUART.Open();

            //RFID
            StartRFID();

            //MOTION SENSOR
            port.OnInterrupt += new NativeEventHandler(motion_OnInterrupt);
            port.EnableInterrupt();

            //TEMPERATURE SENSOR
            SecretLabs.NETMF.Hardware.AnalogInput temp = new SecretLabs.NETMF.Hardware.AnalogInput(Pins.GPIO_PIN_A0);
            const double EFSR = 3.3;
            const int N = 1023;
            int adcValue = 0;
            int adcValueUltrasonic = 0;
            double Q = 0.0;
            double sensorVoltage = 0.0, tempC = 0.0;
            double distanceInCm = 0.0;
            double Kelvin = 0.0;
            double Fahrenheit = 0.0;
            double Newton = 0.0;

            string UltrasonicStatus = "";
            string Status;

            while (true)
            {
                //MOTION SENSOR
                if (MovementDetected)
                {
                    MovementDetected = false;
                }
                //    Debug.Print("Motion detected! Alarm sounding");
                //    sendDataUsingCOMPort("MOTION STATUS=" + "MOTION DETECTED!");
                //    Thread.Sleep(5000);
                //}

                adcValueUltrasonic = sensor.Read();
                adcValue = temp.Read();
                Q = EFSR / N;
                distanceInCm = adcValue * 0.5 * 2.5;

                sensorVoltage = adcValueUltrasonic * Q;
                tempC = System.Math.Abs(100 * (sensorVoltage - 0.5));
                Kelvin = System.Math.Abs(tempC + 273);
                Fahrenheit = System.Math.Abs(tempC * 18 / 10 + 32);
                Newton = System.Math.Abs(tempC * 33 / 100);
                Debug.Print("Distance: " + distanceInCm.ToString("N2"));
                Debug.Print("Temperature: " + tempC.ToString("N2"));

                ButtonState = button.Read();
                if (ButtonState == true)
                {
                    speaker.SetDutyCycle(50);
                    uint duration1 = 3000, duration2 = 2000;
                    Debug.Print("Alarm sounding");
                    for (int i = 0; i < 2; i++)
                    {
                        speaker.SetPulse(duration1 * 2, duration1);
                        Thread.Sleep(200);
                        speaker.SetPulse(duration2 * 2, duration2);
                        Thread.Sleep(200);
                        speaker.SetDutyCycle(0);
                    }
                    sendDataUsingCOMPort("DOORBELL=" + "Push button pressed, activating Camera");
                }
                UltrasonicStatus = "";
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
                
                
                if (tempC > 30)
                {
                    Status = "Hot, on air conditioner";
                    //Status = ">
                }
                if (tempC > 28)
                {
                    Status = "Warm, on fan at high speed";
                }
                if (tempC > 26)
                {
                    Status = "Cool, set fan to low speed or turn off";
                }
                else
                {
                    Status = "Very cool, turn off additional cooling";
                }

                Debug.Print("Temp in C is: " + tempC.ToString("N2"));
                Debug.Print(Status);

                sendDataUsingCOMPort("°C=" + tempC.ToString("N2") + "\n" + "STATUS=" + Status + "\n" + "°K=" + Kelvin.ToString("N2") + "\n" + "°F=" + Fahrenheit.ToString("N2") + "\n" + "°N=" + Newton.ToString("N2") + "\n");
                sendDataUsingCOMPort("DIST CM=" + distanceInCm.ToString("N2") + "\n" + "STATUS=" + UltrasonicStatus + "\n");
                Thread.Sleep(5000);
            }

        }
    }
}
    


