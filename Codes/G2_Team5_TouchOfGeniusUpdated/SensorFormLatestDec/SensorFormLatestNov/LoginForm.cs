using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Mail;

namespace SensorFormLatestNov
{
    public partial class LoginForm : Form
    {
        Int32 cmd = 0;
        public static string ID;
        public static string Username = "";
        SerialPort serialport = new SerialPort();
        //SensorForm f = Application.OpenForms.OfType<SensorForm>().FirstOrDefault();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) //Logging in to the application
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);

            if (txtUsername.Text == "" || txtPassword.Text == "") //Checks for blank textboxes for Username and Password.
            //If blank, message popup 
            {
                AutoClosingMessageBox.Show("Logging in", "Logging in", 1000);
                MessageBox.Show("Please provide username and password");
                txtUsername.BackColor = System.Drawing.Color.Red;
                txtPassword.BackColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(conn); //Checking Users table and Updating Last Login
                    SqlCommand SelectID = new SqlCommand("SELECT UserID from Users where Username=@name", connection);
                    SqlCommand SelectCommand = new SqlCommand("Select * from Users where Username=@name and Password=@Password", connection);
                    SqlCommand UpdateCommand = new SqlCommand("UPDATE Users set LastLogin = @lastlogin where Username=@name", connection);
                    UpdateCommand.Parameters.AddWithValue("@name", txtUsername.Text.Trim());
                    UpdateCommand.Parameters.AddWithValue("@lastlogin", DateTime.Now);
                    SelectCommand.Parameters.AddWithValue("@Password", Encrypt(txtPassword.Text.Trim()));
                    SelectID.Parameters.AddWithValue("@name", txtUsername.Text.Trim());
                    SelectCommand.Parameters.AddWithValue("@name", txtUsername.Text.Trim());
                    connection.Open();
                    SqlDataReader reader = SelectCommand.ExecuteReader();
                    cmd = Convert.ToInt32(SelectID.ExecuteScalar());
                    int count = 0;
                    string Role = string.Empty;
                    while (reader.Read())
                    {
                        count = count + 1;
                        Role = reader["AccessLevel"].ToString();
                    }
                    if (count == 0)
                    {
                        AutoClosingMessageBox.Show("Logging in", "Logging in", 1000);
                        MessageBox.Show("Incorrect username/password/User not found");
                    }
                        //If RFID is incorrect, show incorrect RFID Card message
                        //if (lblRFIDChecking.Text == "Incorrect RFID Card!" || lblRFID1.Text == "-")
                        //{
                        //    AutoClosingMessageBox.Show("Logging in", "Logging in", 1000);
                        //    MessageBox.Show("Incorrect RFID Card. Access Denied.");
                        //}
                        else if (count == 1)
                        {

                            AutoClosingMessageBox.Show("Logging in", "Logging in", 500);
                            //this.Hide();
                            connection.Close();

                            if (Role == "1") //check for role of admin/user
                            {
                                Username = txtUsername.Text;
                                ID = cmd.ToString();
                                AutoClosingMessageBox.Show("Logging in as admin", "Logging in as admin", 1000);
                                //this.Hide();
                                this.Dispose();
                                connection.Open();
                                UpdateCommand.ExecuteNonQuery();
                                connection.Close();
                                SensorForm SensorInterface = new SensorForm();
                                SensorInterface.Show();
                                AdminForm admin = new AdminForm();
                                admin.Show();
                                try
                                {
                                    serialport.Close();
                                    btnDisconnect.Enabled = false;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }
                            }
                            if (Role == "0")
                            {
                                Username = txtUsername.Text;
                                ID = cmd.ToString();
                                connection.Open();
                                UpdateCommand.ExecuteNonQuery();
                                connection.Close();
                                AutoClosingMessageBox.Show("Logging in as user", "Logging in as user", 1000);
                                this.Dispose();
                                //this.Hide();
                                //UserClass.username = txtUsername.Text;
                                //UserClass.userRFID = lblRFID.Text;
                                SensorForm SensorInterface = new SensorForm();
                                SensorInterface.Show();
                                try
                                {
                                    serialport.Close();
                                    btnDisconnect.Enabled = false;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }
                            }
                            else
                            {
                            }
                        }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e) //Clears the textboxes for Username and Password
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
        #region AutoClosingMessageBox
        public class AutoClosingMessageBox //Auto closing messagebox
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

        private string Encrypt(string clearText) //Encrypt method for password
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        //decrypt method
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUsername.Focus();
        }

        //check for RFID association with users
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblRFIDChecking.Text = "";
            txtUsername.BackColor = System.Drawing.Color.White;
            txtPassword.BackColor = System.Drawing.Color.White;
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            //try
            {
                SqlConnection connection = new SqlConnection(conn); //Checking Users table and Updating Last Login
                SqlCommand SelectCommand = new SqlCommand("Select * from RFID where UserID=@name", connection);
                SelectCommand.Parameters.AddWithValue("@name", txtUsername.Text.Trim());
                connection.Open();
                SqlDataReader reader = SelectCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;
                }

                if (count == 0)
                {
                    {
                        lblRFIDText.Visible = false;
                        label4.Visible = false;
                        lblRFIDString.Visible = false;
                        lblRFID.Visible = false;
                        lblRFID1.Visible = false;
                    }
                }
                else if (count == 1)
                {
                    lblRFIDString.Visible = true;
                    lblRFID.Visible = true;
                    lblRFID1.Visible = true;
                    lblRFIDText.Visible = true;
                    label4.Visible = true;
                    string RFIDCheck = "An RFID card is assigned to User " + "'" + txtUsername.Text.Trim() + "'" + "." + Environment.NewLine + "Please scan your RFID corresponding to your key ";
                    lblRFID.Text = RFIDCheck;
                    lblRFID.ForeColor = System.Drawing.Color.Red;
                    reader.Close();
                    //Check for RFID string if both match
                    if (lblRFID.Text == RFIDCheck)
                    {
                        SqlDataReader rd = SelectCommand.ExecuteReader();
                        reader.Close();
                        while (rd.Read())
                        {
                            string RFIDString;
                            RFIDString = rd["RfidID"].ToString();
                            lblRFIDText.Text = RFIDString.Replace(" ", String.Empty);
                        }
                    }
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string[] strPortNames = SerialPort.GetPortNames();
            foreach (string strName in strPortNames)
                cbCommPorts.Items.Add(strName);
        }


        public void updateInfo()
        {
            try
            {
                string dt = DateTime.Now.ToString();

                string strData = "";
                strData = serialport.ReadTo("\n");
                string display = dt + ": " + strData;
                lbReadings.Items.Insert(0, display);

                ExtractInformation(strData);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
        private string getNetduinoStringValue(string strData, string ID)
        {
            string result = strData.Substring(strData.IndexOf(ID) + ID.Length);
            return result;
        }
        private void ExtractInformation(string strData)
        {
            if (strData.IndexOf("CARD=") != -1)
            {
                string strCardID = getNetduinoStringValue(strData, "CARD=");
                string strCard = strCardID.Replace(" ", String.Empty);

                lblRFID1.Text = strCardID;
                if (strCard == lblRFIDText.Text)
                {
                    lblRFID1.ForeColor = System.Drawing.Color.Green;
                    lblRFIDChecking.Visible = true;
                    lblRFIDChecking.ForeColor = System.Drawing.Color.Green;
                    lblRFIDChecking.Text = "Correct RFID Card!";
                }
                else if (strCard != lblRFIDText.Text)
                {
                    lblRFID1.ForeColor = System.Drawing.Color.Red;
                    lblRFIDChecking.Visible = true;
                    lblRFIDChecking.ForeColor = System.Drawing.Color.Red;
                    lblRFIDChecking.Text = "Incorrect RFID Card!";
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbCommPorts.SelectedIndex == -1)
            {
                MessageBox.Show("You must select the port first!");
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
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lblRFID1_Click(object sender, EventArgs e)
        {
        }

        private void lblRFID1_TextChanged(object sender, EventArgs e)
        {
        }

        private void RFIDCheck()
        {
            if (lblRFID1.Text == lblRFIDText.Text)
            {
                lblRFIDChecking.Visible = true;
                lblRFIDChecking.ForeColor = System.Drawing.Color.Green;
                lblRFIDChecking.Text = "Correct RFID Card!";
            }
            else if (lblRFID1.Text != lblRFIDText.Text)
            {
                lblRFIDChecking.Visible = true;
                lblRFIDChecking.ForeColor = System.Drawing.Color.Red;
                lblRFIDChecking.Text = "Incorrect RFID Card!";
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialport.Close();
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = System.Drawing.Color.White;
            txtPassword.BackColor = System.Drawing.Color.White;
        }
        }
    }
    

