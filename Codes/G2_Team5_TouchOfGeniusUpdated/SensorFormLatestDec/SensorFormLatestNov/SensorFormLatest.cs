using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//NETDUINO
using System.IO;
using System.IO.Ports;
using System.Threading;
//DATABASES
using System.Configuration;
using System.Data.SqlClient;
//SYSTEM DRAWING IMAGING
using System.Drawing.Imaging;
//ENCRYPTION/DECRYPTION
using System.Security.Cryptography;
//EXCEL
using Excel = Microsoft.Office.Interop.Excel;
//CHARTS
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using System.Web;
using System.Xml;
//CAMERA
using AForge;
using System.Runtime.InteropServices;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Net.Mail;
using System.Net;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;
using System.Diagnostics;

namespace SensorFormLatestNov
{
    public partial class SensorForm : Form
    {
        #region data members
        public static string ID;
        public static string Username;
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        SerialPort serialport = new SerialPort();
        int randomNumber;
        private int prevIndex = -1;
        ChartArea CA;
        Series S1;
        VerticalLineAnnotation VA;
        RectangleAnnotation RA;
        private bool AtHome = false;
        private bool Outside = false;

        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        #endregion

        public SensorForm()
        {
            InitializeComponent();
            chartTemp.MouseWheel += new MouseEventHandler(chartTemp_MouseWheel);
            chartUltrasonic.MouseWheel += new MouseEventHandler(chartUltrasonic_MouseWheel);
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye 
            try
            {
                //Load previous trained faces and labels for each image 
                string Labelinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                //Error Catching for empty DataSet 
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) //Log out the user
        {
            AutoClosingMessageBox.Show("Logging out", "Logging out", 500);
            this.Hide();
            SensorForm sensorinterface = new SensorForm();
            sensorinterface.Dispose();
            sensorinterface.Close();

            LoginForm fl = new LoginForm();
            fl.Show();
            serialport.Close();
        }

        private void TimeNow_Tick(object sender, EventArgs e) //method to get timer
        {
            lblLocal.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            lblSecurityCamera.Text = "LIVE " + DateTime.Now.ToString("MM/dd/yyyy HHH:mm:ss");
        }

        private void btnDisconnect_Click(object sender, EventArgs e) //Disconnect the port
        {
            try
            {
                serialport.Close();
                tbPortStatus.Text = "Port Not Opened";
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Disconnected port. All operations stopped." }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + ex.Message.ToString() }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            }
        }

        private void btnConnect_Click(object sender, EventArgs e) //Connect to the port
        {
            if (cbCommPorts.SelectedIndex == -1)
            {
                MessageBox.Show("You must select the port first!");
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Attempting to connect..." }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Please select a port first!" }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            }
            else
            {
                if (serialport.IsOpen)
                    serialport.Close();
                try
                {
                    serialport.PortName = cbCommPorts.Text;
                    serialport.BaudRate = 9600;
                    serialport.Parity = Parity.None;
                    serialport.DataBits = 8;
                    serialport.StopBits = StopBits.One;
                    serialport.Encoding = System.Text.Encoding.UTF8;
                    serialport.ReadTimeout = 1000;

                    serialport.Open();
                    serialport.DataReceived += new SerialDataReceivedEventHandler(datareceived);
                    btnDisconnect.Enabled = false;
                    tbPortStatus.Text = "OPEN";
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Connected to port " + cbCommPorts.SelectedItem.ToString() }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + ex.Message.ToString() }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
                }
            }
        }

        public delegate void myDelegate();

        void datareceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                myDelegate d = new myDelegate(updateInfo);

                lbReadings.Invoke(d, new object[] { });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void updateInfo()
        {
            try
            {
                string dt = DateTime.Now.ToString();

                string strData = "";
                strData = serialport.ReadTo("\n");
                string display = dt + ": " + strData;

                if (strData.IndexOf("CARD=") != -1)
                {
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 15), FontStyle.Italic) } });
                }
                if (strData.IndexOf("°C=") != 1)
                {
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                }
                if (strData.IndexOf("MOTION=") != -1)
                {
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                }
                //if (strData.IndexOf("DIST CM=") != -1)
                //{
                //    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.LightGreen }, { "ForeColor", Color.Green }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                //}
                if (strData.IndexOf("DOORBELL=") != -1)
                {
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                }

                ExtractInformation(strData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
        }

        #region Netduino
        private string getNetduinoStringValue(string strData, string ID) //Method to get the passed string data type
        {
            string result = strData.Substring(strData.IndexOf(ID) + ID.Length);
            return result;
        }
        private float getNetduinoFloatValue(string strData, string ID) //Method to get the passed float data type
        {
            string result = strData.Substring(strData.IndexOf(ID) + ID.Length);
            return (float.Parse(result));
        }
        private void ExtractInformation(string strData) //Extract information from the passed strings
        {
            if (strData.IndexOf("CARD=") != -1)
            {
                string strCardID = getNetduinoStringValue(strData, "CARD=");
                string strCard = strCardID.Replace(" ", String.Empty);

                RFIDID.Text = strCardID;

                if (RFIDID.Text == "66006C1C63")
                {
                    gpPreset.Text = "Preset for " + RFIDID.Text;
                    lblConfigurations.Text = "Configurations for " + RFIDID.Text;
                    AutoClosingMessageBox.Show("Loading Configuration " + RFIDID.Text, "Loading Configuration " + RFIDID.Text, 500);
                    tabPageRFID1.Text = "RFID " + RFIDID.Text;
                    this.tabControlForm.SelectTab("RFID " + RFIDID.Text);
                    tabPageRFID1.Enabled = true;
                    tabPageRFID1.Visible = true;
                    cbUltrasonicSensitivity.SelectedIndex = 1;
                    cbAircon.SelectedIndex = 1;
                    cbFanSpeed.SelectedIndex = 1;

                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Configuration for RFID " + RFIDID.Text }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Sensitivity of ultrasonic sensor is configured at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm for activating switches" }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Temperature sensor is configured to turn on the air conditioner "
                        + "at " + cbAircon.SelectedItem.ToString() + " °C" }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Fan speed is configured at " + cbFanSpeed.SelectedItem.ToString() }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Duration of lights is configured at " + txtLightDuration.Text + " minutes" }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                }
                if (RFIDID.Text == "66006C221E")
                {
                    gpPreset.Text = "Preset for " + RFIDID.Text;
                    lblConfigurations.Text = "Configurations for " + RFIDID.Text;
                    AutoClosingMessageBox.Show("Loading Configuration " + RFIDID.Text, "Loading Configuration " + RFIDID.Text, 500);
                    tabPageRFID1.Text = "RFID " + RFIDID.Text;
                    tabPageRFID1.Enabled = true;
                    tabPageRFID1.Visible = true;
                    this.tabControlForm.SelectTab(tabPageRFID1);
                    cbUltrasonicSensitivity.SelectedIndex = 2;
                    cbAircon.SelectedIndex = 2;
                    cbFanSpeed.SelectedIndex = 2;
                    txtLightDuration.Text = "180";

                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Configuration for RFID " + RFIDID.Text }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Sensitivity of ultrasonic sensor is configured at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm for activating switches" }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Temperature sensor is configured to turn on the air conditioner "
                        + "at " + cbAircon.SelectedItem.ToString() + " °C" }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Fan speed is configured at " + cbFanSpeed.SelectedItem.ToString() }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Duration of lights is configured at " + txtLightDuration.Text + " minutes" }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                }
                if (RFIDID.Text == "6A003E3998")
                {
                    gpPreset.Text = "Preset for " + RFIDID.Text;
                    lblConfigurations.Text = "Configurations for " + RFIDID.Text;
                    AutoClosingMessageBox.Show("Loading Configuration " + RFIDID.Text, "Loading Configuration " + RFIDID.Text, 500);
                    tabPageRFID1.Text = "RFID " + RFIDID.Text;
                    tabPageRFID1.Enabled = true;
                    tabPageRFID1.Visible = true;
                    this.tabControlForm.SelectTab(tabPageRFID1);
                    cbUltrasonicSensitivity.SelectedIndex = 4;
                    cbAircon.SelectedIndex = 4;
                    cbFanSpeed.SelectedIndex = 2;
                    txtLightDuration.Text = "240";

                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Configuration for RFID " + RFIDID.Text }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Sensitivity of ultrasonic sensor is configured at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm for activating switches" }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Temperature sensor is configured to turn on the air conditioner "
                        + "at " + cbAircon.SelectedItem.ToString() + " °C" }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Fan speed is configured at " + cbFanSpeed.SelectedItem.ToString() }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Duration of lights is configured at " + txtLightDuration.Text + " minutes" }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                }
                if (RFIDID.Text == "66006C1191")
                {
                    gpPreset.Text = "Preset for " + RFIDID.Text;
                    lblConfigurations.Text = "Configurations for " + RFIDID.Text;
                    AutoClosingMessageBox.Show("Loading Configuration " + RFIDID.Text, "Loading Configuration " + RFIDID.Text, 500);
                    tabPageRFID1.Text = "RFID " + RFIDID.Text;
                    tabPageRFID1.Enabled = true;
                    tabPageRFID1.Visible = true;
                    this.tabControlForm.SelectTab(tabPageRFID1);
                    cbUltrasonicSensitivity.SelectedIndex = 5;
                    cbAircon.SelectedIndex = 5;
                    cbFanSpeed.SelectedIndex = 0;
                    txtLightDuration.Text = "320";

                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Configuration for RFID " + RFIDID.Text }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Sensitivity of ultrasonic sensor is configured at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm for activating switches" }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Temperature sensor is configured to turn on the air conditioner "
                        + "at " + cbAircon.SelectedItem.ToString() + " °C" }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Fan speed is configured at " + cbFanSpeed.SelectedItem.ToString() }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Duration of lights is configured at " + txtLightDuration.Text + " minutes" }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                }
                if (RFIDID.Text == "66006BFAA5")
                {
                    gpPreset.Text = "Preset for " + RFIDID.Text;
                    lblConfigurations.Text = "Configurations for " + RFIDID.Text;
                    AutoClosingMessageBox.Show("Loading Configuration " + RFIDID.Text, "Loading Configuration " + RFIDID.Text, 500);
                    tabPageRFID1.Text = "RFID " + RFIDID.Text;
                    tabPageRFID1.Enabled = true;
                    tabPageRFID1.Visible = true;
                    this.tabControlForm.SelectTab(tabPageRFID1);
                    cbUltrasonicSensitivity.SelectedIndex = 7;
                    cbAircon.SelectedIndex = 7;
                    cbFanSpeed.SelectedIndex = 2;
                    txtLightDuration.Text = "400";

                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Configuration for RFID " + RFIDID.Text }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Sensitivity of ultrasonic sensor is configured at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm for activating switches" }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Temperature sensor is configured to turn on the air conditioner "
                        + "at " + cbAircon.SelectedItem.ToString() + " °C" }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Fan speed is configured at " + cbFanSpeed.SelectedItem.ToString() }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Duration of lights is configured at " + txtLightDuration.Text + " minutes" }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                }
                if (RFIDID.Text == "66006C1ECB")
                {
                    gpPreset.Text = "Preset for " + RFIDID.Text;
                    lblConfigurations.Text = "Configurations for " + RFIDID.Text;
                    AutoClosingMessageBox.Show("Loading Configuration " + RFIDID.Text, "Loading Configuration " + RFIDID.Text, 500);
                    tabPageRFID1.Text = "RFID " + RFIDID.Text;
                    tabPageRFID1.Enabled = true;
                    tabPageRFID1.Visible = true;
                    this.tabControlForm.SelectTab(tabPageRFID1);
                    cbUltrasonicSensitivity.SelectedIndex = 8;
                    cbAircon.SelectedIndex = 3;
                    cbFanSpeed.SelectedIndex = 2;
                    txtLightDuration.Text = "180";

                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Configuration for RFID " + RFIDID.Text }, { "BackColor", Color.Blue }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Sensitivity of ultrasonic sensor is configured at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm for activating switches" }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Temperature sensor is configured to turn on the air conditioner "
                        + "at " + cbAircon.SelectedItem.ToString() + " °C" }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Fan speed is configured at " + cbFanSpeed.SelectedItem.ToString() }, { "BackColor", Color.Red }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + RFIDID.Text + ":" + " Duration of lights is configured at " + txtLightDuration.Text + " minutes" }, { "BackColor", Color.Orange }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 14), FontStyle.Regular) } });
                }
            }
            if (strData.IndexOf("°C=") != -1) //Temperature string and also inserts temperature information into the database
            {
                float temp = getNetduinoFloatValue(strData, "°C=");

                tbTemp.Text = temp + "";

                tbRoomTemp.Text = temp + "";

                if (temp > 30)
                {
                    tbTempStatus.Text = "Hot, on air conditioner";
                }
                else if (temp > 28)
                {
                    tbTempStatus.Text = "Warm, on fan at high speed";
                }
                else if (temp > 26)
                {
                    tbTempStatus.Text = "Cool, set fan to low speed or turn off";
                }
                else
                {
                    tbTempStatus.Text = "Very cool, turn off additional cooling";
                }
                insertTemp();
                double kelvin = temp + 273.15;
                double fahrenheit = temp * 9 / 5 + 32;
                tbTempF.Text = fahrenheit.ToString("N2");
                tbTempK.Text = kelvin.ToString("N2");
                lblTmp.Text = tbTemp.Text + "°C";
                lblSuggestion.Text = tbTempStatus.Text;
                lblTmp.ForeColor = System.Drawing.Color.Red;
                lblSuggestion.ForeColor = System.Drawing.Color.Blue;

                timerTemperature.Interval = 1000; //Update every 5 seconds
                timerTemperature.Tick += new EventHandler(timerTemperature_Tick);
                timerTemperature.Start();
                //lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text" }, { "BackColor", Color.White }, { "ForeColor", Color.Blue }, { "Font", new Font(new Font("Arial", 15), FontStyle.Italic) } });
            }

            if (strData.IndexOf("MOTION=") != -1) //Motion string, trigger when motion sensor detects movement
            {
                if (Outside)
                {
                    lbReadings.Items.Add(new Dictionary<string, object> { { "Text", DateTime.Now + " You're outside, motion sensor has started" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                    btnOutside.Enabled = false;
                    string strMotion = getNetduinoStringValue(strData, "MOTION=");
                    sendCommand("A");
                    sendCommand("N");
                    groupBoxMotion.ForeColor = Color.Blue;
                    groupBoxTemperature.ForeColor = Color.Black;
                    groupBoxUltrasonic.ForeColor = Color.Black;
                    string MotionSensor = "==========================MOTION SENSOR==========================";
                    tbMotionSensor.Text = "Motion detected on " + DateTime.Now + ". " + "Alarm and Camera activated";
                    insertMotion();
                    string Motion = tbMotionSensor.Text;
                    lbReadings.Items.Add(new Dictionary<string, object> { { "Text", DateTime.Now + " " + MotionSensor }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                    lbReadings.Items.Add(new Dictionary<string, object> { { "Text", DateTime.Now + " " + Motion }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });

                    //btnOffBuzzer.Visible = true;
                    //insertMotion();
                    //List all available video sources. (That can be webcams as well as tv cards, etc)
                    FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                    //Check if atleast one video source is available
                    if (videosources != null)
                    {
                        //For example use first video device. You may check if this is your webcam.
                        videoSource = new VideoCaptureDevice(videosources[0].MonikerString);

                        try
                        {
                            //Check if the video device provides a list of supported resolutions
                            if (videoSource.VideoCapabilities.Length > 0)
                            {
                                string highestSolution = "0;0";
                                //Search for the highest resolution
                                for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                                {
                                    if (videoSource.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                        highestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                                }
                                //Set the highest resolution as active
                                videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];
                            }
                        }
                        catch { }

                        //Create NewFrame event handler
                        //(This one triggers every time a new frame/image is captured
                        videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                        //Start recording
                        videoSource.Start();
                        btnStartCamera.Visible = false;
                        btnStop.Visible = true;
                        lblStatus.Visible = true;
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        lblStatus.Text = "STARTING CAMERA...";
                        lblStatus.Text = "CAMERA IS ON";
                        lblSecurityCamera.Visible = true;
                    }
                }
                if (AtHome)
                {
                    string strMotion = getNetduinoStringValue(strData, "NULL");
                    lbReadings.Items.Add(new Dictionary<string, object> { { "Text", DateTime.Now + " You're at home, motion sensor has stopped." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                    videoSource = null;
                    btnAthome.Enabled = false;
                    btnOutside.Enabled = true;
                }
            }

            if (strData.IndexOf("DOORBELL=") != -1)
            {
                sendCommand("A");
                videoSource = null;
                string pushbutton = getNetduinoStringValue(strData, "DOORBELL=");
                DoorView facialcamera = new DoorView();
                facialcamera.Show();

                videoSource.SignalToStop();
                videoSource = null;
            }
            if (strData.IndexOf("DIST CM=") != -1) //Distance string, trigger when ultrasonic sensor detects movement and inserts information into database
            {
                float Distance = getNetduinoFloatValue(strData, "DIST CM=");
                tbUltraSonic.Text = Distance + "";
                tbUltrasonicReading.Text = Distance + "";

                if (Distance < 30)
                {
                    tbUltraSonicStatus.Text = "You turned the lights and switches ON";
                }

                if (Distance > 30 && Distance < 50)
                {
                    tbUltraSonicStatus.Text = "Move your hand a little closer to turn lights and switches ON";
                }
                if (Distance > 51)
                {
                    tbUltraSonicStatus.Text = "Unreachable distance, lights and switches OFF";
                }
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "ULTRASONIC SENSOR STATUS=" + tbUltraSonicStatus.Text + "\n" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.Crimson }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                //insertUltrasonic();
                timerUltrasonic.Interval = 1000;
                timerUltrasonic.Tick += new EventHandler(timerUltrasonic_Tick);
                timerUltrasonic.Start();
                insertUltrasonic();
            }

        }

        void FrameGrabber(object sender, EventArgs e)
        {
            lblnumface.Text = "0";
            NamePersons.Add("");

            //Get current Frame from capture device 
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert to GrayScale 
            gray = currentFrame.Convert<Gray, byte>();

            //Face Detection 
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                lblnumface.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces
                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }
                 
                */
            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            camImage.Image = currentFrame;
            lblfacedetected.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }
        #endregion

        public void sendCommand(string strCommand) //Method to send commands
        {
            try
            {
                byte[] sendBytes = Encoding.UTF8.GetBytes(strCommand);
                serialport.Write(sendBytes, 0, strCommand.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + ex.Message.ToString() }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            }
        }

        private void btnOnLED_Click(object sender, EventArgs e)
        {
            sendCommand("N");
        }

        private void btnOffLED_Click(object sender, EventArgs e)
        {
            sendCommand("F");
        }

        private void btnSendCmd_Click(object sender, EventArgs e)
        {
            sendCommand(tbCmdStr.Text);
            lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Attempting to send command to Netduino..." }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
        }
        #region AutoClosingMessageBox
        public class AutoClosingMessageBox //Method for messagebox that closes automatically
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
        #endregion

        private void btnBuzzer_Click(object sender, EventArgs e) //Sends command to turn on the buzzer
        {
            sendCommand("A");
        }

        private void btnOffBuzzer_Click(object sender, EventArgs e) //Turn off buzzer alarm
        {
            sendCommand("B");
            //btnOffBuzzer.Visible = false;
        }

        #region FormLoad
        private void SensorForm_Load_1(object sender, EventArgs e) //form load event
        {
            txtID.Text = LoginForm.ID;
            txtUsername.Text = "Welcome " + LoginForm.Username;
            tabPageRFID1.Enabled = false;
            tabPageRFID1.Visible = false;
            //txtUser.Text = UserClass.username;
            //txtUserRFID.Text = UserClass.userRFID;
            lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + txtUsername.Text }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            fillUltrasonicChart();
            fillTempChart();
            Random slumpGenerator = new Random(); //Generate a random string to allocate to the sessionID
            int num = slumpGenerator.Next(0, 1000);
            lblSession.Text = num.ToString();
            System.Windows.Forms.Timer TimeNow = new System.Windows.Forms.Timer(); //Start timer
            TimeNow.Interval = 1000;//ticks every 1 second
            TimeNow.Tick += new EventHandler(TimeNow_Tick);
            TimeNow.Start();
            //lbReadings.Items.Add("Welcome to TOUCH OF GENIUS." + " Current session ID is " + lblSession.Text);

            string[] strPortNames = SerialPort.GetPortNames(); //Initiate port in Combobox
            foreach (string strName in strPortNames)
            {
                cbCommPorts.Items.Add(strName);
                cbCommPorts.SelectedItem = strName;
            }
            if (serialport.IsOpen)
                serialport.Close();
            try
            {
                serialport.PortName = cbCommPorts.Text;
                serialport.BaudRate = 9600;
                serialport.Parity = Parity.None;
                serialport.DataBits = 8;
                serialport.StopBits = StopBits.One;
                serialport.Encoding = System.Text.Encoding.UTF8;
                serialport.ReadTimeout = 1000;

                //Thread.Sleep(2000);
                serialport.Open();
                serialport.DataReceived += new SerialDataReceivedEventHandler(datareceived);
                btnDisconnect.Enabled = false;
                tbPortStatus.Text = "OPEN";
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Connected to port " + cbCommPorts.SelectedItem.ToString() }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });

                chartTemp.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

                chartTemp.ChartAreas["Temperature"].AxisX.Title = "Time(s)";
                chartTemp.ChartAreas["Temperature"].AxisY.Title = "Temperature";

                chartUltrasonic.ChartAreas["Distance"].AxisX.Title = "Time(s)";
                chartUltrasonic.ChartAreas["Distance"].AxisY.Title = "Distance";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Netduino not connected");
                lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Netduino not connected" }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            }
        }
        #endregion

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise
            //you'll probably get access violation exceptions
            pictureBox.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
        }

        #region CamList
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //comboBox1.Items.Clear();
                //if (videoDevices.Count == 0)
                //    throw new ApplicationException();
                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    //    comboBox1.Items.Add(device.Name);
                }
                //comboBox1.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                MessageBox.Show("No capture device on your system");
            }
        }
        #endregion

        private void insertUltrasonic() //Insert into ultrasonic table method
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("Insert into Ultrasonic(UserID, Distance, Timestamp) VALUES (@UserID, @dist, @time)", connection);
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                            cmd.Parameters.AddWithValue("@dist", tbUltraSonic.Text);
                            cmd.Parameters.AddWithValue("@time", DateTime.Now);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message:" + ex.Message);
                    }
                }
            }
        }

        private void insertMotion() //insert into motion DB method
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("Insert into Motion (UserID, Timestamp) VALUES (@UserID, @Timestamp)", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd.Parameters.AddWithValue("@TimeStamp", DateTime.Now);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }

        private void insertTemp() //Insert into temperature table method
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("Insert into Temperature (UserID, Temperature, Timestamp) VALUES (@UserID, @Temp, @TimeStamp)", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        DateTime time = DateTime.Now;
                        cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd.Parameters.AddWithValue("@Temp", tbRoomTemp.Text);
                        cmd.Parameters.AddWithValue("@TimeStamp", time);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        //bindTemperature();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbReadings.Text = String.Empty;
        }

        #region FillTempChart
        //method to generate gridview with temperature DB
        private void fillTempChart()
        {
            try
            {
                String conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select Temperature, Timestamp from Temperature WHERE UserID=@userID", con);
                adapter.SelectCommand.Parameters.AddWithValue("@userID", txtID);
                chartTemp.Titles.Add("Temperature sensor");
                adapter.Fill(ds);
                chartTemp.DataSource = ds;
                chartTemp.Series["Temperature"].XValueMember = "Timestamp";
                chartTemp.Series["Temperature"].YValueMembers = "Temperature";
                chartTemp.ChartAreas["Temperature"].AxisX.LabelStyle.Format = "HH:mm:ss";
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region FillUltrasonicChart
        //method to generate gridview with ultrasonic DB
        private void fillUltrasonicChart()
        {
            try
            {
                String conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select Distance, Timestamp from Ultrasonic WHERE UserID=@userID", con);
                adapter.SelectCommand.Parameters.AddWithValue("@userID", txtID);
                adapter.Fill(ds);
                chartUltrasonic.DataSource = ds;
                chartUltrasonic.Series["Distance"].XValueMember = "Timestamp";
                chartUltrasonic.Series["Distance"].YValueMembers = "Distance";
                chartUltrasonic.Titles.Add("Ultrasonic sensor");
                chartUltrasonic.ChartAreas["Distance"].AxisX.LabelStyle.Format = "HH:mm:ss";
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region TabControl
        private void tabControlForm_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            SolidBrush fillbrush = new SolidBrush(Color.Red);

            //draw rectangle behind the tabs
            Rectangle lasttabrect = tabControlForm.GetTabRect(tabControlForm.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);

            //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
            background.Size = new Size(tabControlForm.Right - background.Left, lasttabrect.Height + 1);
            e.Graphics.FillRectangle(fillbrush, background);
        }
        #endregion


        #region TimerTemperature
        //method to refresh temperature chart using timer every 1 second interval
        DateTime threeDays = new DateTime();
        DateTime timeNow = new DateTime();
        private void timerTemperature_Tick(object sender, EventArgs e)
        {
            threeDays = DateTime.Now.AddDays(-3);
            timeNow = DateTime.Now;
            String conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Temperature, Timestamp from Temperature WHERE UserID=@userID", con);
            adapter.SelectCommand.Parameters.AddWithValue("@userID", txtID.Text);
            adapter.Fill(ds);
            chartTemp.DataSource = ds;
            chartTemp.Series["Temperature"].XValueMember = "Timestamp";
            chartTemp.Series["Temperature"].YValueMembers = "Temperature";
            chartTemp.ChartAreas["Temperature"].AxisX.LabelStyle.Format = "HH:mm:ss";
            if (chartTemp.ChartAreas[0].AxisX.Maximum > chartTemp.ChartAreas[0].AxisX.ScaleView.Size)
            {
                chartTemp.ChartAreas[0].AxisX.ScaleView.Scroll(chartTemp.ChartAreas[0].AxisX.Maximum);
            }

            chartTemp.Series[0].BackGradientStyle = GradientStyle.TopBottom;
            chartTemp.Series[0].Color = System.Drawing.Color.Crimson;
            chartTemp.Series[0].BackSecondaryColor = System.Drawing.Color.LightBlue;
            chartTemp.Series[0].BorderColor = System.Drawing.ColorTranslator.FromHtml("#AA3131");
            chartTemp.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            chartTemp.Series[0].BorderWidth = 1;
            con.Close();
        }
        #endregion

        #region TimerUltrasonic
        //method to refresh chart using timer every 1 second interval
        private void timerUltrasonic_Tick(object sender, EventArgs e)
        {
            String conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Distance, Timestamp from Ultrasonic WHERE UserID=@userID", con);
            adapter.SelectCommand.Parameters.AddWithValue("@userID", txtID.Text);
            adapter.Fill(ds);
            chartUltrasonic.DataSource = ds;
            chartUltrasonic.Series["Distance"].XValueMember = "Timestamp";
            chartUltrasonic.Series["Distance"].YValueMembers = "Distance";
            chartUltrasonic.ChartAreas["Distance"].AxisX.LabelStyle.Format = "HH:mm:ss";
            if (chartUltrasonic.ChartAreas[0].AxisX.Maximum > chartUltrasonic.ChartAreas[0].AxisX.ScaleView.Size)
            {
                chartUltrasonic.ChartAreas[0].AxisX.ScaleView.Scroll(chartUltrasonic.ChartAreas[0].AxisX.Maximum);
            }
            con.Close();
        }
        #endregion

        //stops camera
        private void SensorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop and free the webcam object if application is closing
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }

        private void btnStop_Click(object sender, EventArgs e) //stop camera recording
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
            lblStatus.Visible = true;
            lblStatus.Text = "STOPPING CAMERA";
            lblStatus.Text = "CAMERA STOPPED";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            btnStop.Visible = false;
            btnStartCamera.Visible = true;
            lblSecurityCamera.Visible = false;
        }

        #region StartCamera
        private void btnStartCamera_Click(object sender, EventArgs e) //start camera recording
        {
            //List all available video sources. (That can be webcams as well as tv cards, etc)
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if (videosources != null)
            {
                //For example use first video device. You may check if this is your webcam.
                videoSource = new VideoCaptureDevice(videosources[0].MonikerString);

                try
                {
                    //Check if the video device provides a list of supported resolutions
                    if (videoSource.VideoCapabilities.Length > 0)
                    {
                        string highestSolution = "0;0";
                        //Search for the highest resolution
                        for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                        {
                            if (videoSource.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                highestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                        }
                        //Set the highest resolution as active
                        videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];
                    }
                }
                catch { }

                //Create NewFrame event handler
                //(This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Start recording
                videoSource.Start();
                lblStatus.Visible = true;
                lblStatus.Text = "STARTING CAMERA...";
                lblStatus.Text = "CAMERA IS ON";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                btnStartCamera.Visible = false;
                btnStop.Visible = true;
                lblSecurityCamera.Visible = true;
            }
        }
        #endregion

        //return to main tab
        private void btnGoback_Click(object sender, EventArgs e)
        {
            this.tabControlForm.SelectedTab = this.tabControlForm.TabPages[1];
        }

        //proceed to security camera
        private void btnGoSecurityCamera_Click(object sender, EventArgs e)
        {
            this.tabControlForm.SelectedTab = this.tabControlForm.TabPages[2];
        }

        //save image from video
        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            if (videoSource == null)
            {
                MessageBox.Show("No video");
            }
            else
            {
                SaveFileDialog sdlog = new SaveFileDialog();
                String photoTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                sdlog.FileName = "SNAPSHOT" + photoTime;
                sdlog.DefaultExt = ".jpg";
                sdlog.Filter = "Image (.jpg)|*.jpg";

                if (sdlog.ShowDialog() == DialogResult.OK)
                {

                    string filename = sdlog.FileName;
                    FileStream fstream = new FileStream(filename, FileMode.Create);
                    // MemoryStream ms = new MemoryStream();
                    pictureBox2.BackgroundImage.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fstream.Close();
                }


            }
        }
        #region

        private int GetLinesNumber(string text)
        {
            int count = 1;
            int pos = 0;
            while ((pos = text.IndexOf("\r\n", pos)) != -1) { count++; pos += 2; }
            return count;
        }
        //for formatting listbox inserted items
        private void lbReadings_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Dictionary<string, object> props = (this.lbReadings.Items[e.Index] as Dictionary<string, object>);
                SolidBrush backgroundBrush = new SolidBrush(props.ContainsKey("BackColor") ? (Color)props["BackColor"] : e.BackColor);
                SolidBrush foregroundBrush = new SolidBrush(props.ContainsKey("ForeColor") ? (Color)props["ForeColor"] : e.ForeColor);
                Font textFont = props.ContainsKey("Font") ? (Font)props["Font"] : e.Font;
                string text = props.ContainsKey("Text") ? (string)props["Text"] : string.Empty;
                RectangleF rectangle = new RectangleF(new PointF(e.Bounds.X, e.Bounds.Y), new SizeF(e.Bounds.Width, g.MeasureString(text, textFont).Height));

                g.FillRectangle(backgroundBrush, rectangle);
                g.DrawString(text, textFont, foregroundBrush, rectangle);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //clear listbox data
        private void btnCLEAR_Click_1(object sender, EventArgs e)
        {
            lbReadings.Items.Clear();
            lbReadings.BackColor = System.Drawing.Color.White;
        }

        #region
        private void lbSmoke_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSmoke.SelectedIndex == -1)
            {
                MessageBox.Show("Choose an option!");
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show temperature database")
            {
                ID = txtID.Text;
                Username = txtUsername.Text;
                TemperatureForm temp = new TemperatureForm();
                temp.Show();
                temp.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded temperature database." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show ultrasonic database")
            {
                ID = txtID.Text;
                Username = txtUsername.Text;
                UltrasonicForm ultra = new UltrasonicForm();
                ultra.Show();
                ultra.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded ultrasonic database." }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show motion database")
            {
                ID = txtID.Text;
                Username = txtUsername.Text;
                MotionForm motion = new MotionForm();
                motion.Show();
                motion.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded motion database." }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show gas database")
            {
                GasForm gas = new GasForm();
                gas.Show();
                gas.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded gas database." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
            }
            else if (lbSmoke.SelectedItem.ToString() == "Save temperature chart")
            {
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Saved temperature chart." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg";
                saveFileDialog.Title = "Save Chart As Image File";
                saveFileDialog.FileName = "Sample" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png";

                DialogResult result = saveFileDialog.ShowDialog();
                saveFileDialog.RestoreDirectory = true;

                if (result == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    try
                    {
                        if (saveFileDialog.CheckPathExists)
                        {
                            if (saveFileDialog.FilterIndex == 2)
                            {
                                chartTemp.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                            }
                            else if (saveFileDialog.FilterIndex == 1)
                            {
                                chartTemp.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Given Path does not exist");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (lbSmoke.SelectedItem.ToString() == "Save ultrasonic chart")
            {
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Saved ultrasonic chart." }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg";
                saveFileDialog.Title = "Save Chart As Image File";
                saveFileDialog.FileName = "Sample" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png";

                DialogResult result = saveFileDialog.ShowDialog();
                saveFileDialog.RestoreDirectory = true;

                if (result == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    try
                    {
                        if (saveFileDialog.CheckPathExists)
                        {
                            if (saveFileDialog.FilterIndex == 2)
                            {
                                chartUltrasonic.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                            }
                            else if (saveFileDialog.FilterIndex == 1)
                            {
                                chartUltrasonic.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Given Path does not exist");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        private void chartTemp_MouseLeave(object sender, EventArgs e)
        {
            if (chartTemp.Focused)
                chartTemp.Parent.Focus();
            timerTemperature.Start();
        }
        void chartTemp_MouseEnter(object sender, EventArgs e)
        {
            if (!chartTemp.Focused)
                chartTemp.Focus();
            timerTemperature.Stop();
        }
        private void chartUltrasonic_MouseWheel(object sender, MouseEventArgs e)
        {
            timerUltrasonic.Stop();
            chartUltrasonic.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartUltrasonic.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartUltrasonic.ChartAreas[0].CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartUltrasonic.ChartAreas[0].CursorX.Interval = 0.5D;

            chartUltrasonic.ChartAreas[0].AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Minutes;
            chartUltrasonic.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 0.5D;
            chartUltrasonic.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartUltrasonic.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy HH:mm:ss";
            chartUltrasonic.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chartUltrasonic.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
        }
        #endregion

        #region
        private void chartTemp_MouseWheel(object sender, MouseEventArgs e)
        {
            timerTemperature.Stop();
            chartTemp.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartTemp.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartTemp.ChartAreas[0].CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartTemp.ChartAreas[0].CursorX.Interval = 0.5D;

            chartTemp.ChartAreas[0].AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Minutes;
            chartTemp.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 0.5D;
            chartTemp.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartTemp.ChartAreas["Temperature"].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartTemp.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chartTemp.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
            //try
            //{
            //    if (e.Delta < 0)
            //    {
            //        chartTemp.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            //        chartTemp.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            //    }
            //
            //    if (e.Delta > 0)
            //    {
            //        double xMin = chartTemp.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            //        double xMax = chartTemp.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            //        double yMin = chartTemp.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            //        double yMax = chartTemp.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

            //        double posXStart = (chartTemp.ChartAreas["Temperature"].AxisX.PixelPositionToValue(e.Location.X) + xMin) / 2;
            //        double posXFinish = (chartTemp.ChartAreas["Temperature"].AxisX.PixelPositionToValue(e.Location.X) + xMax) / 2;
            //        double posYStart = (chartTemp.ChartAreas["Temperature"].AxisY.PixelPositionToValue(e.Location.Y) + yMin) / 2;
            //        double posYFinish = (chartTemp.ChartAreas["Temperature"].AxisY.PixelPositionToValue(e.Location.Y) + yMax) / 2;
            //
            //        chartTemp.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
            //          chartTemp.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
            //       }
            //     }
            //      catch { }
        }

        private Point _mousePos;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private void chartTemp_MouseMove(object sender, MouseEventArgs e)
        {
            timerTemperature.Stop();

            if (e.Button != MouseButtons.Left) return;
            if (!_mousePos.IsEmpty)
            {
                var style = chartTemp.ChartAreas[0].Area3DStyle;
                style.Rotation = Math.Min(180, Math.Max(-180,
                    style.Rotation - (e.Location.X - _mousePos.X)));
                style.Inclination = Math.Min(90, Math.Max(-90,
                    style.Inclination + (e.Location.Y - _mousePos.Y)));
            }
            _mousePos = e.Location;

            try
            {
                var pos = e.Location;
                if (prevPosition.HasValue && pos == prevPosition.Value)
                    return;
                tooltip.RemoveAll();
                prevPosition = pos;
                var results = chartTemp.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                    {
                        var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                        tooltip.Show(((int)yVal).ToString() + " C", chartTemp, pos.X, pos.Y - 15);
                    }
                }
                // Call Hit Test Method
                HitTestResult resulting = chartTemp.HitTest(e.X, e.Y);
                if (resulting.ChartElementType == ChartElementType.DataPoint)
                {
                    //chartTemp.Series[0].Points[resulting.PointIndex].Color = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartTemp_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void chartUltrasonic_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chartUltrasonic.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    tooltip.Show(((int)yVal).ToString(), chartUltrasonic, pos.X, pos.Y - 15);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                lbReadings.Items.Clear();
                lbReadings.BackColor = System.Drawing.Color.White;
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " Cleared status and reading history" }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartUltrasonic_MouseLeave(object sender, EventArgs e)
        {
            timerUltrasonic.Start();
        }

        private void chartUltrasonic_MouseMove_1(object sender, MouseEventArgs e)
        {
            timerUltrasonic.Stop();
        }

        private void chartUltrasonic_MouseEnter(object sender, EventArgs e)
        {
            timerUltrasonic.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved configurations for preset " + RFIDID.Text + "\n" + "Sensitivity of ultrasonic sensor "
                + "set at " + cbUltrasonicSensitivity.SelectedItem.ToString() + " cm" + "\n" + "Configured air conditioner to "
                + "turn on at " + cbAircon.SelectedItem.ToString() + " °C" + "\n" + "Configured fan speed at " + cbFanSpeed.SelectedItem.ToString()
                + "\n" + "Configured duration of lights at " + txtLightDuration.Text + " minutes");
            lbReadings.Items.Add(new Dictionary<string, object> { { "Text", DateTime.Now + " You saved a configuration for " + RFIDID.Text}, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
        }

        private void SensorForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            //deleteTemperature();
            //deleteUltrasonic();
            //deleteMotion();
        }

        private void deleteTemperature() //delete ultrasonic sensor data
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Temperature", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        //bindTemperature();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }

        private void deleteMotion() //delete motion sensor data
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Motion", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }

        private void deleteUltrasonic() //delete ultrasonic sensor data
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Ultrasonic", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }

        private void chartTemp_MouseClick(object sender, MouseEventArgs e)
        {
            chartTemp.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
        }

        private void btnOutside_Click(object sender, EventArgs e)
        {
            btnOutside.Enabled = false;
            Outside = true;
            AtHome = false;
            btnAthome.Enabled = true;
            pictureBox.Visible = true;
            pictureBox2.Visible = true;
            sendCommand("Y");
        }

        private void btnAthome_Click(object sender, EventArgs e)
        {
            btnAthome.Enabled = false;
            AtHome = true;
            Outside = false;
            btnOutside.Enabled = true;
            pictureBox.Visible = false;
            pictureBox2.Visible = false;
            sendCommand("Z");
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            videoSource = null;
            //Initialise Image Capture 
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialise FrameGrab Event 
            Application.Idle += new EventHandler(FrameGrabber);
            btnstart.Enabled = false;
        }

        private void btnsavedata_Click(object sender, EventArgs e)
        {
            try
            {
                //Trained Face Counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from Capture device 
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector 
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                    face,
                    1.2,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));

                //Action for each element detected 
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //Resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(tbname.Text);

                //Show face added in gray scale 
                trainingimage.Image = TrainedFace;

                //Write the number of trained faces in file text for further loading 
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of trained faces ina file text for loading 
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                //Display message to show successful data added 
                MessageBox.Show(tbname.Text + "'s face has been detected and added to DataSet.", "Training  OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Enable face detection", "Training FAILED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
    
        #endregion