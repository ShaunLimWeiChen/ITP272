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

namespace SensorFormLatestNov
{
    public partial class SensorForm : Form
    {
        #region data members
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        SerialPort serialport = new SerialPort();
        int randomNumber;
        #endregion

        public SensorForm()
        {
            InitializeComponent();
            chartTemp.MouseWheel += new MouseEventHandler(chartTemp_MouseWheel);
            chartUltrasonic.MouseWheel += new MouseEventHandler(chartUltrasonic_MouseWheel);
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
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 15), FontStyle.Italic) } });
                }
                if (strData.IndexOf("TEMP=") != 1)
                {
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                    lbReadings.BackColor = System.Drawing.Color.Crimson;
                }
                else
                {
                    lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", display }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
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

            if (strData.IndexOf("TEMP IN CELCIUS=") != -1) //Temperature string and also inserts temperature information into the database
            {
                float temp = getNetduinoFloatValue(strData, "TEMP IN CELCIUS=");

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
                tbTempF.Text = fahrenheit.ToString();
                tbTempK.Text = kelvin.ToString();

                timerTemperature.Interval = 1000; //Update every 5 seconds
                timerTemperature.Tick += new EventHandler(timerTemperature_Tick);
                timerTemperature.Start();
            }

            if (strData.IndexOf("MOTION STATUS=") != -1) //Motion string, trigger when motion sensor detects movement
            {
                string strMotion = getNetduinoStringValue(strData, "MOTION STATUS="); ;
                sendCommand("A");
                sendCommand("N");
                groupBoxMotion.ForeColor = Color.Blue;
                groupBoxTemperature.ForeColor = Color.Black;
                groupBoxUltrasonic.ForeColor = Color.Black;
                string MotionSensor = "==========================MOTION SENSOR==========================";
                tbMotionSensor.Text = "Motion detected on " + DateTime.Now + ". " + "Alarm and Camera activated";
                insertMotion();
                string Motion = tbMotionSensor.Text;
                lbReadings.Items.Add(new Dictionary<string, object> { { "Text", MotionSensor }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                lbReadings.Items.Add(new Dictionary<string, object> { { "Text", Motion }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });

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
                if (strData.IndexOf("PUSH BUTTON STATUS=") != -1)
                {
                    string pushbutton = getNetduinoStringValue(strData, "PUSH BUTTON STATUS=");
                    FacialReconDoorbell facialcamera = new FacialReconDoorbell();
                    facialcamera.Show();
                    SensorForm sensor = new SensorForm();
                    sensor.Close();
                }
                    if (strData.IndexOf("DISTANCE IN CM=") != -1) //Distance string, trigger when ultrasonic sensor detects movement and inserts information into database
                    {
                        float Distance = getNetduinoFloatValue(strData, "DISTANCE IN CM=");
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
                        lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "ULTRASONIC SENSOR STATUS=" + tbUltraSonicStatus.Text + "\n" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                        //insertUltrasonic();
                        timerUltrasonic.Interval = 1000;
                        timerUltrasonic.Tick += new EventHandler(timerUltrasonic_Tick);
                        timerUltrasonic.Start();
                        insertUltrasonic();
                    }
            
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
            //txtUser.Text = UserClass.username;
            //txtUserRFID.Text = UserClass.userRFID;
            this.txtTemperatureManual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TempEnter);
            this.txtUltrasonic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DistanceEnter);
            lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", "Welcome to the Smart Home System." }, { "BackColor", Color.White }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 12), FontStyle.Bold) } });
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
                    SqlCommand cmd = new SqlCommand("Insert into Ultrasonic(Distance, Timestamp) VALUES (@dist, @time)", connection);
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
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
                SqlCommand cmd = new SqlCommand("Insert into Motion (Timestamp) VALUES (@Timestamp)", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
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
                SqlCommand cmd = new SqlCommand("Insert into Temperature (Temperature, Timestamp) VALUES (@Temp, @TimeStamp)", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        DateTime time = DateTime.Now;
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
            String conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Temperature, Timestamp from Temperature", con);
            chartTemp.Titles.Add("Temperature sensor");
            adapter.Fill(ds);
            chartTemp.DataSource = ds;
            chartTemp.Series["Temperature"].XValueMember = "Timestamp";
            chartTemp.Series["Temperature"].YValueMembers = "Temperature";
            chartTemp.ChartAreas["Temperature"].AxisX.LabelStyle.Format = "HH:mm:ss";
        }
        #endregion

        #region FillUltrasonicChart
        //method to generate gridview with ultrasonic DB
        private void fillUltrasonicChart()
        {
            String conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Distance, Timestamp from Ultrasonic", con);
            adapter.Fill(ds);
            chartUltrasonic.DataSource = ds;
            chartUltrasonic.Series["Distance"].XValueMember = "Timestamp";
            chartUltrasonic.Series["Distance"].YValueMembers = "Distance";
            chartUltrasonic.Titles.Add("Ultrasonic sensor");
            chartUltrasonic.ChartAreas["Distance"].AxisX.LabelStyle.Format = "HH:mm:ss";
            con.Close();
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

        #region Temperature
        //enter temperature manually and insert into DB
        private void button1_Click(object sender, EventArgs e)
        {
            this.lbReadings.DrawItem += new DrawItemEventHandler(lbReadings_DrawItem);
            {
                if (txtTemperatureManual.Text == "")
                {
                    MessageBox.Show("Please enter temperature data");
                    this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Please enter temperature sensor data!" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                }
                else
                {
                    try
                    {
                        tbTemp.Text = txtTemperatureManual.Text;
                        tbRoomTemp.Text = txtTemperatureManual.Text;
                        insertTemp();
                        float Temp = float.Parse(tbTemp.Text);
                        {
                            if (Temp > 30)
                            {
                                tbTempStatus.Text = "Hot, on air conditioner";
                                SendTempEmail("rocketmail9797@gmail.com", "151719K@mymail.nyp.edu.sg");
                            }
                            else if (Temp > 28)
                            {
                                tbTempStatus.Text = "Warm, on fan at high speed";
                            }
                            else if (Temp > 26)
                            {
                                tbTempStatus.Text = "Cool, set fan to low speed or turn off";
                            }
                            else
                            {
                                tbTempStatus.Text = "Very cool, turn off additional cooling";
                            }
                            groupBoxTemperature.ForeColor = Color.Crimson;
                            groupBoxUltrasonic.ForeColor = Color.Black;
                            groupBoxMotion.ForeColor = Color.Black;
                            double kelvin = Temp + 273.15;
                            double fahrenheit = Temp * 9 / 5 + 32;
                            double newton = Temp * 33 / 100;
                            tbTempK.Text = kelvin.ToString("N2");
                            tbTempF.Text = fahrenheit.ToString("N2");
                            string tempSensor = "==========================TEMPERATURE SENSOR==========================";
                            string Temperature = "Time: " + DateTime.Now;
                            string Temperature1 = DateTime.Now + " TEMP: " + tbRoomTemp.Text + " degree celcius";
                            string Temperature2 = DateTime.Now + " TEMP STATUS: " + tbTempStatus.Text;
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", Temperature2 }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " TEMP IN NEWTON=" + newton.ToString("N2") + " N" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " TEMP IN FAHRENHEIT=" + fahrenheit.ToString("N2") + " F" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " TEMP IN KELVIN=" + kelvin.ToString("N2") + " K" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", Temperature1 }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", tempSensor }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", Temperature }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            lbReadings.BackColor = System.Drawing.Color.Crimson;
                            tabControlForm.TabPages[2].BackColor = Color.Crimson;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message:" + ex.Message);
                    }
                }
            }
        } 
               public void SendTempEmail(string from, string to) 
              {

               SmtpClient client = new SmtpClient("smtp.gmail.com");
               MailAddress from1 = new MailAddress(from);
               MailAddress to1 = new MailAddress(to);
               MailMessage message = new MailMessage(from1, to1);
               client.Port = 587;
               client.Credentials = new System.Net.NetworkCredential("rocketmail9797@gmail.com", "456eurrty789");
               client.EnableSsl = true;
               message.Body = "This email was sent automatically by the smart home system. A temperature reading of " + tbTemp.Text + " degrees celcius was detected by the Smart Home System's Environment Temperature Sensor."
                   + " If your home has an unusually high temperature, the cause might be a lack of ventilation, air circulation or cooling system.";
               message.Subject = "Temperature Alert";
               client.SendCompleted += new SendCompletedEventHandler(tempSmtpClient_OnCompleted);
               string userState = "Temperature Alert";

               client.SendAsync(message, userState);
              }

 
        
               public static void tempSmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
              {
            //Get the Original MailMessage object
               String token = (string) e.UserState;


               if (e.Cancelled)
              {
               MessageBox.Show("Send canceled for mail with subject " + token.ToString());
            }
            if (e.Error != null)
            {
              Console.WriteLine("Error " + e.Error.ToString() + " occurred");
            }
            else
            {
               Console.WriteLine("Temperature alert sent to 151719K@mymail.nyp.edu.sg.");
            }      
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
            SqlDataAdapter adapter = new SqlDataAdapter("Select Temperature, Timestamp from Temperature WHERE Timestamp > 2017-1-18 ", con);
            adapter.Fill(ds);
            chartTemp.DataSource = ds;
            chartTemp.Series["Temperature"].XValueMember = "Timestamp";
            chartTemp.Series["Temperature"].YValueMembers = "Temperature";
            chartTemp.ChartAreas["Temperature"].AxisX.LabelStyle.Format = "HH:mm:ss";
            if (chartTemp.ChartAreas[0].AxisX.Maximum > chartTemp.ChartAreas[0].AxisX.ScaleView.Size)
            {
                chartTemp.ChartAreas[0].AxisX.ScaleView.Scroll(chartTemp.ChartAreas[0].AxisX.Maximum);
            }
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
            SqlDataAdapter adapter = new SqlDataAdapter("Select Distance, Timestamp from Ultrasonic", con);
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

        #region Ultrasonic
        //enter ultrasonic sensor distance manually and insert data into DB
        private void btnUltrasonic_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                if (txtUltrasonic.Text == "")
                {
                    MessageBox.Show("Please enter ultrasonic sensor data");
                    this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " +  "Please enter ultrasonic sensor data!" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into Ultrasonic (Distance, Timestamp) VALUES (@Distance, @TimeStamp)", connection);
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@Distance", txtUltrasonic.Text.Trim());
                            cmd.Parameters.AddWithValue("@TimeStamp", DateTime.Now);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            tbUltrasonicReading.Text = txtUltrasonic.Text;
                            tbUltraSonic.Text = txtUltrasonic.Text;
                            float Distance;
                            if (float.TryParse(txtUltrasonic.Text, out Distance))
                            {
                                if (Distance < 30)
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
                            groupBoxUltrasonic.ForeColor = Color.Green;
                            groupBoxTemperature.ForeColor = Color.Black;
                            groupBoxMotion.ForeColor = Color.Black;
                            string UltraSensor = "==========================ULTRASONIC SENSOR==========================";
                            string Ultrasonic = DateTime.Now + " DISTANCE: " + txtUltrasonic.Text + " cm";
                            string Ultrasonic1 = DateTime.Now + " STATUS: " + tbUltraSonicStatus.Text;
                            lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", Ultrasonic1 }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", Ultrasonic }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("arial", 12), FontStyle.Regular) } });
                            lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", UltraSensor }, { "BackColor", Color.Green }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
                            tabControlForm.TabPages[2].BackColor = Color.Green;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message:" + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region Movement
        //simulate movement and pass information to listbox and textbox to indicate movement detected, also activate camera
        private void Movement_Click(object sender, EventArgs e)
        {
            groupBoxMotion.ForeColor = Color.Blue;
            groupBoxTemperature.ForeColor = Color.Black;
            groupBoxUltrasonic.ForeColor = Color.Black;
            string MotionSensor = "==========================MOTION SENSOR==========================";
            tbMotionSensor.Text = "Motion detected on " + DateTime.Now + ". " + "Alarm and Camera activated";
            insertMotion();
            string Motion = tbMotionSensor.Text;
            lbReadings.Items.Add(new Dictionary<string, object> { { "Text", MotionSensor }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
            lbReadings.Items.Add(new Dictionary<string, object> { { "Text", Motion }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Regular) } });
            //btnOffBuzzer.Visible = true;
            //insertMotion();
            sendCommand("A");
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
                tabControlForm.TabPages[2].BackColor = Color.White;
                SendEmail("rocketmail9797@gmail.com", "151719K@mymail.nyp.edu.sg");
            }
        }
        public void SendEmail(string from, string to)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            MailAddress from1 = new MailAddress(from);
            MailAddress to1 = new MailAddress(to);
            MailMessage message = new MailMessage(from1, to1);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("rocketmail9797@gmail.com", "456eurrty789");
            client.EnableSsl = true;
            message.Body = "This email was sent automatically by the smart home system. Movement was detected by our system in your house on " + DateTime.Now + ". Security surveillance camera was activated and will take snapshots of movements and have heightened monitoring of faces.";
            message.Subject = "Motion Alert";
            client.SendCompleted += new SendCompletedEventHandler(MySmtpClient_OnCompleted);
            string userState = "Motion Alert";

            client.SendAsync(message, userState);
        }



        public static void MySmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the Original MailMessage object
            String token = (string)e.UserState;


            if (e.Cancelled)
            {
                MessageBox.Show("Send canceled for mail with subject " + token.ToString());
            }
            if (e.Error != null)
            {
                Console.WriteLine("Error " + e.Error.ToString() + " occurred");
            }
            else
            {
                Console.WriteLine("Motion alert sent to 151719K@mymail.nyp.edu.sg.");
            }
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
        //for formatting listbox inserted items
        private void lbReadings_DrawItem(object sender, DrawItemEventArgs e)
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
                MessageBox.Show("Choose a concentration of gas!");
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show temperature database")
            {
                TemperatureForm
                temp = new TemperatureForm();
                temp.Show();
                temp.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded temperature database." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show ultrasonic database")
            {
                UltrasonicForm ultra = new UltrasonicForm();
                ultra.Show();
                ultra.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded ultrasonic database." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
            }
            else if (lbSmoke.SelectedItem.ToString() == "Show motion database")
            {
                MotionForm motion = new MotionForm();
                motion.Show();
                motion.BringToFront();
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Loaded motion database." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
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
            else if (lbSmoke.SelectedItem.ToString() == "Save gas chart")
            {
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
                                chartSmoke.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                            }
                            else if (saveFileDialog.FilterIndex == 1)
                            {
                                chartSmoke.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
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
            else
            {
                string[] Tip = new string[6];
                Tip[0] = "We've detected harmful amounts of smoke. Please notify your neighbours after you come home.";
                Tip[1] = "Harmful amounts of gas concentrations are unusual, unless you have forgotten to turn off a stove or a flammable" + "\n" + "item has caught fire.";
                Tip[2] = "The application will always alert the nearest fire stations 20 seconds after detection";
                Tip[3] = "Never store flammable items near stoves.";
                Tip[4] = "Always turn off stoves and switches after using.";
                Tip[5] = "Never leave stoves and switches on when you leave the house.";
                rtbSmoke.Text = "Concentration of " + "'" + lbSmoke.GetItemText(lbSmoke.SelectedItem) + "'" + " was detected on " + DateTime.Now + "\n";
                Random random = new Random();
                randomNumber = random.Next(100, 1000);
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", "___________________________________________________________________________________________________________________" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "You selected " + lbSmoke.GetItemText(lbSmoke.SelectedItem) + " to simulate" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "SMOKE ALERT: " + randomNumber + " ppm(parts per million) " + rtbSmoke.Text.Trim() + "\n" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "SMOKE ALERT: A high amount of harmful gas concentration is detected" + "\n" }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Alerting the nearest fire station in 20 seconds." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", DateTime.Now + " " + "Alarm activated." }, { "BackColor", Color.Crimson }, { "ForeColor", Color.White }, { "Font", new Font(new Font("Arial", 12), FontStyle.Italic) } });
                Random r1 = new Random();

                this.lbReadings.Items.Insert(0, new Dictionary<string, object> { { "Text", "WARNING: " + (Tip[r1.Next(Tip.Length)]) }, { "BackColor", Color.Crimson }, { "ForeColor", Color.Black }, { "Font", new Font(new Font("Arial", 10), FontStyle.Underline) } });
                string[] xValues = { lbSmoke.GetItemText(lbSmoke.SelectedItem) + DateTime.Now.ToString("HH:mm:ss") };
                int[] yNames = { randomNumber };
                chartSmoke.Font = new System.Drawing.Font("Trebuchet MS", 12F);
                chartSmoke.Series[0].Points.AddXY(lbSmoke.SelectedItem.ToString() + " " + randomNumber.ToString(), Convert.ToInt64(yNames[0]));
                lblDetected.Visible = true;
                lblDetected.ForeColor = System.Drawing.Color.Crimson;
                lblDetected.Text = randomNumber + " ppm of " + lbSmoke.GetItemText(lbSmoke.SelectedItem) + "\n" + "detected!!!";
                lbReadings.BackColor = System.Drawing.Color.Crimson;
                chartSmoke.ChartAreas[0].AxisX.Interval = 1;
                chartSmoke.ChartAreas[0].AxisY.Interval = 1;
                chartSmoke.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartSmoke.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chartSmoke.Series[0].IsValueShownAsLabel = true;
                sendCommand("A");
                SendMyEmail("rocketmail9797@gmail.com", "151719K@mymail.nyp.edu.sg");
            }
        }
               public  void SendMyEmail(string from, string to) 
              {

               SmtpClient client = new SmtpClient("smtp.gmail.com");
               MailAddress from1 = new MailAddress(from);
               MailAddress to1 = new MailAddress(to);
               MailMessage message = new MailMessage(from1, to1);
               client.Port = 587;
               client.Credentials = new System.Net.NetworkCredential("rocketmail9797@gmail.com", "456eurrty789");
               client.EnableSsl = true;
               message.Body = "This email was sent automatically by the smart home system. " + randomNumber + " ppm(parts per million) " + rtbSmoke.Text.Trim() + ". We've alerted the nearest fire station near your home to dispatch firefighting services.";
               message.Subject = "Gas Alert";
               client.SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);
               string userState = "Gas Alert";

               client.SendAsync(message, userState);
              }

               public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
              {
            //Get the Original MailMessage object
               String token = (string) e.UserState;


               if (e.Cancelled)
              {
               MessageBox.Show("Send canceled for mail with subject " + token.ToString());
              }
               if (e.Error != null)
              {
               Console.WriteLine("Error " + e.Error.ToString() + " occurred");
              }
               else
              {
               Console.WriteLine("Gas alert sent to 151719K@mymail.nyp.edu.sg.");
              }
        } 
        private void btnClear_Click_2(object sender, EventArgs e)
        {
            chartSmoke.Series[0].Points.Clear();
            lblDetected.Visible = false;
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
            chartTemp.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy HH:mm:ss";
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

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private void chartTemp_MouseMove(object sender, MouseEventArgs e)
        {
            timerTemperature.Stop();
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


        private void chartSmoke_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chartSmoke.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    tooltip.Show(((int)yVal).ToString() + " ppm", chartSmoke, pos.X, pos.Y - 15);
                }
            }
        }

        private void chartTemp_MouseDown(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            HitTestResult result = chartTemp.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                //chartTemp.Series[0].Points[result.PointIndex].Color = Color.Green;
            }
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
        private void TempEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnInsertTemp.PerformClick();
            }
        }
        private void DistanceEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnUltrasonic.PerformClick();
            }
        }

        private Point _mousePos;
        private void chartSmoke_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (!_mousePos.IsEmpty)
            {
                var style = chartSmoke.ChartAreas[0].Area3DStyle;
                style.Rotation = Math.Min(180, Math.Max(-180,
                    style.Rotation - (e.Location.X - _mousePos.X)));
                style.Inclination = Math.Min(90, Math.Max(-90,
                    style.Inclination + (e.Location.Y - _mousePos.Y)));
            }
            _mousePos = e.Location;
            ChartArea area = new ChartArea();
            area.AxisX.IsLabelAutoFit = true;
            area.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
            area.AxisX.LabelStyle.Enabled = true;
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
    }
}
        #endregion