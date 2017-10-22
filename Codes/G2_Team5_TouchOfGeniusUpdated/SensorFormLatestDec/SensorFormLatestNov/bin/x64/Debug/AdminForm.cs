using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;
using System.IO;
using System.Collections.Specialized;

namespace SensorFormLatestNov
{
    public partial class AdminForm : Form
    {
        //Data
        private DataGridViewCellStyle _normalStyle;
        private DataGridViewCellStyle _boldStyle;
        SqlDataAdapter pagingAdapter;
        DataSet pagingDS;
        int scrollVal;

        public AdminForm()
        {
            InitializeComponent();
            //Initializes the fontfaces and styles for datagridview
            _normalStyle = new DataGridViewCellStyle();
            _normalStyle.Font = new System.Drawing.Font("Arial", 10F, FontStyle.Regular);
            _boldStyle = new DataGridViewCellStyle();
            _boldStyle.Font = new System.Drawing.Font("Arial", 10F, FontStyle.Bold);
            AdminGridView.CellMouseEnter += new DataGridViewCellEventHandler(AdminGridView_CellMouseEnter);
            AdminGridView.CellMouseLeave += new DataGridViewCellEventHandler(AdminGridView_CellMouseLeave);
            scrollVal = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e) //Adding administrator account
        {
            {
                string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                {
                    if (txtUsername.Text == "" || txtPassword.Text == "" || txtEmail.Text == "") //Checks blank username, password and email 
                    {
                        AutoClosingMessageBox.Show("Adding user", "Adding user", 500);
                        MessageBox.Show("Please provide username and password and email");
                    }
                    if (txtUsername.Text != "" && txtPassword.Text != "" && txtEmail.Text != "" && !UserNameCheck()) //Checks username, password and email and existing user
                    {
                        using (SqlConnection connection = new SqlConnection(conn))
                        {
                            string cmd1 = "Insert into Users (Username, Password, Email, DateCreated, AccessLevel) VALUES (@Username, @Password, @Email, @DateCreated, @AccessLevel)";
                            string cmd2 = "Insert into RFID (RFIDId, DateCreated, UserID) VALUES (@RFIDUser, @DateCreation, @UserID)";
                            try
                            {
                                using (SqlCommand cmd = new SqlCommand("", connection))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandText = cmd1;
                                    DateTime myDateTime = DateTime.Now;
                                    string SqlFormattedString = myDateTime.ToString("dd-MM-yyyy");
                                    DateTime time = DateTime.Now;              // Use current time
                                    Random r1 = new Random();
                                    string[] RFID = new string[6];
                                    RFID[0] = "66006C1C63";
                                    RFID[1] = "66006C221E";
                                    RFID[2] = "6A003E3998";
                                    RFID[3] = "66006C1191";
                                    RFID[4] = "66006BFAA5";
                                    RFID[5] = "66006C1ECB";
                                    string RFID1 = (RFID[r1.Next(RFID.Length)]).Replace(" ", String.Empty);
                                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Password", Encrypt(txtPassword.Text.Trim()));
                                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                    cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@AccessLevel", 1);
                                    cmd.Parameters.AddWithValue("@RFIDUser", RFID1);
                                    cmd.Parameters.AddWithValue("@DateCreation", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UserID", txtUsername.Text.Trim());
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                    cmd.CommandText = cmd2;
                                    cmd.ExecuteNonQuery();
                                    AutoClosingMessageBox.Show("Adding user", "Adding user", 500);
                                    DisplayData();
                                }

                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else if (AdminNameCheck())
                    {
                    }
                }
            }
        }


        private void DisplayData() //Loads the data of the Users onto the datagridview, and allows paging
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            string sql = "SELECT * from Users";
            SqlConnection con = new SqlConnection(conn);
            pagingAdapter = new SqlDataAdapter(sql, con);
            pagingDS = new DataSet();
            con.Open();
            pagingAdapter.Fill(pagingDS, scrollVal, 5, "Users");
            con.Close();
            AdminGridView.DataSource = pagingDS;
            AdminGridView.DataMember = "Users";
            DataGridViewRow row = this.AdminGridView.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 35;
            row.MinimumHeight = 20;
            lblUsers.Text = AdminGridView.RowCount.ToString();
            ReadOnly();
            //AdminGridView.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        //int PageSize = 5;

        private void AdminForm_Load(object sender, EventArgs e) //Initializes timer and loading datagridview
        {
            System.Windows.Forms.Timer TimeNow = new System.Windows.Forms.Timer();
            TimeNow.Interval = 1000;//ticks every 1 second
            TimeNow.Tick += new EventHandler(TimeNow_Tick);
            TimeNow.Start();
            DisplayData();
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e) //Refreshes and reloads datagridview
        {
            AutoClosingMessageBox.Show("Refreshing records", "Refreshing records", 500);
            DisplayData();
        }


        public static string GenerateRandomString(int length) //Method to generate random string to allocate to individual users
        {
            //It will generate string with combination of small,capital letters and numbers
            char[] charArr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            string randomString = string.Empty;
            Random objRandom = new Random();
            for (int i = 0; i < length; i++)
            {
                //Don't Allow Repetation of Characters
                int x = objRandom.Next(1, charArr.Length);
                if (!randomString.Contains(charArr.GetValue(x).ToString()))
                    randomString += charArr.GetValue(x);
                else
                    i--;
            }
            return randomString;
        }

        private string Encrypt(string clearText) //Encryption method for password
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

        private void btnGenerate_Click(object sender, EventArgs e) //Generates a random password string for users which is optional
        {
            string randomstring = GenerateRandomString(10);
            lblPassword.Text = randomstring.ToString();
            lblPassword.Visible = true;
            txtPassword.PasswordChar = '\0';
            txtPassword.Text = lblPassword.Text;
            timer1.Start();
            timer1.Interval = 2000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblPassword.Visible = false;
            txtPassword.PasswordChar = '*';
            timer1.Stop();
        }
        public class AutoClosingMessageBox //Auto closing message box 
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

        private void btnEdit_Click(object sender, EventArgs e) //Allows editing which clears existing textboxes pointing towards the selected user
        {
            txtUserID.ForeColor = System.Drawing.Color.Red;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            btnUpdate.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e) //Deletes the user selected in the table
        {
            if (txtUserID.Text != "")
            {
                string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string cmd1 = "DELETE FROM Users where UserID=@uid";
                    string cmd2 = "DELETE FROM RFID where UserID=@Username";
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("", connection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = cmd1;
                            cmd.Parameters.AddWithValue("@uid", txtUserID.Text.Trim());
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = cmd2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            AutoClosingMessageBox.Show("Deleting user", "Deleting user", 500);
                            DisplayData();
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
                AutoClosingMessageBox.Show("Deleting user", "Deleting user", 500); //Does not delete if no user is selected
                MessageBox.Show("Please select a record to Delete");
            }
            txtUserID.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }

        private void btnLogout_Click(object sender, EventArgs e) //Log out
        {
            AutoClosingMessageBox.Show("Logging out", "Logging out", 500);
            this.Hide();
            LoginForm fl = new LoginForm();
            fl.Show();
        }

        private void TimeNow_Tick(object sender, EventArgs e)
        {
            lblLocalTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }


        public bool UserNameCheck() //Checks for existing usernames to prevent duplicate usernames upon adding
        {
            string con = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand("Select count(*) from Users where Username= @uname", conn);
            cmd.Parameters.AddWithValue("@uname", this.txtUsername.Text.Trim());
            conn.Open();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            if (TotalRows > 0)
            {
                AutoClosingMessageBox.Show("Adding user", "Adding user", 500);
                MessageBox.Show("This username already exists");

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdminNameCheck() //Checks for usernames existing in database to prevent duplicates upon adding
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("Select count(*) from Users where Username= @uname", con);
            cmd.Parameters.AddWithValue("@uname", this.txtUsername.Text.Trim());
            con.Open();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            if (TotalRows > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        private void AdminGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {  //Clicking within datagridview to select users for CRUD
            try
            {

                int ID = Convert.ToInt32(AdminGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtUserID.Text = ID.ToString();
                txtUsername.Text = AdminGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = AdminGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = AdminGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPassword.PasswordChar = '\0';
                timer1.Start();
                timer1.Interval = 2000;
                txtPassword.Text = "";
                txtEmail.Text = "";
            }
            catch (FormatException Fe)
            {
                txtUserID.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtEmail.Text = "";
                MessageBox.Show("No record" + Fe.Message);
            }
            var rowIndex = e.RowIndex;
            if (rowIndex < 0 || rowIndex >= AdminGridView.Rows.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0) //column header / row headers
            {
                return;
            }

            this.AdminGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightBlue;
            AdminGridView.Rows[rowIndex].DefaultCellStyle = _boldStyle;
        }

        private void btnClear_Click(object sender, EventArgs e) //Clears textboxes
        {
            txtUserID.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
        }

        private void button1_Click(object sender, EventArgs e) //Adding users
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || txtEmail.Text == "")
                {
                    AutoClosingMessageBox.Show("Adding user", "Adding user", 500);
                    MessageBox.Show("Please provide username and password and email");
                }
                if (txtUsername.Text != "" && txtPassword.Text != "" && txtEmail.Text != "" && !UserNameCheck())
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        string cmd1 = "Insert into Users (Username, Password, Email, DateCreated, AccessLevel) VALUES (@Username, @Password, @Email, @DateCreated, @AccessLevel)";
                        string cmd2 = "Insert into RFID (RFIDId, DateCreated, UserID) VALUES (@RFIDUser, @DateCreation, @UserID)";
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("", connection))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = cmd1;
                                DateTime myDateTime = DateTime.Now;
                                string SqlFormattedString = myDateTime.ToString("dd-MM-yyyy");
                                DateTime time = DateTime.Now;              // Use current time
                                Random r1 = new Random();
                                string[] RFID = new string[6]; //generate RFID strings and randomize assign to into users
                                RFID[0] = "66006C1C63";
                                RFID[1] = "66006C221E";
                                RFID[2] = "6A003E3998";
                                RFID[3] = "66006C1191";
                                RFID[4] = "66006BFAA5";
                                RFID[5] = "66006C1ECB";
                                string RFID1 = (RFID[r1.Next(RFID.Length)]).Replace(" ", String.Empty);
                                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                                cmd.Parameters.AddWithValue("@Password", Encrypt(txtPassword.Text.Trim()));
                                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                                cmd.Parameters.AddWithValue("@AccessLevel", 0);
                                cmd.Parameters.AddWithValue("@RFIDUser", RFID1);
                                cmd.Parameters.AddWithValue("@DateCreation", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UserID", txtUsername.Text.Trim());

                                connection.Open();
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = cmd2;
                                cmd.ExecuteNonQuery();
                                AutoClosingMessageBox.Show("Adding user", "Adding user", 500);
                                DisplayData();
                            }

                        }

                        catch (Exception ex)
                        {
                            if (ex is FormatException || ex is OverflowException || ex is ArgumentNullException || ex is SqlException)
                                MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (AdminNameCheck())
                {
                }
            }


        }

        private void AdminGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex < 0 || rowIndex >= AdminGridView.Rows.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0) //column header / row headers
            {
                return;
            } this.AdminGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;

            AdminGridView.Rows[rowIndex].DefaultCellStyle = _normalStyle;
        }

        private void AdminGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex < 0 || rowIndex >= AdminGridView.Rows.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0) //column header / row headers
            {
                return;
            }

            this.AdminGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightBlue;
            AdminGridView.Rows[rowIndex].DefaultCellStyle = _boldStyle;
        }

        private void AdminGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex < 0 || rowIndex >= AdminGridView.Rows.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0) //column header / row headers
            {
                return;
            }

            this.AdminGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightBlue;
            AdminGridView.Rows[rowIndex].DefaultCellStyle = _boldStyle;
        }

        private void btnUpdate_Click(object sender, EventArgs e) //Update method for users
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                string con = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("Update Users set Username=@username, Password=@password, Email=@Email where UserID=@id", conn);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@id", txtUserID.Text);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", Encrypt(txtPassword.Text.Trim()));
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        AutoClosingMessageBox.Show("Updated", "Updated", 500);
                        DisplayData();
                        btnUpdate.Visible = false;
                    }
                }
            }
            else
            {
                AutoClosingMessageBox.Show("Updating admin", "Updating admin", 500);
                MessageBox.Show("Please select a record to Update");
                btnUpdate.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e) //Pagination for 5 records next
        {
            try
            {
                scrollVal = scrollVal + 5;
                if (scrollVal > 23)
                {
                    scrollVal = 18;
                }
                pagingDS.Clear();
                pagingAdapter.Fill(pagingDS, scrollVal, 5, "Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load the records first!");
            }
        }

        private void btnminusfive_Click(object sender, EventArgs e) //Pagination for 5 records previous
        {
            try
            {
                scrollVal = scrollVal - 5;
                if (scrollVal < 0)
                {
                    scrollVal = 0;
                }
                pagingDS.Clear();
                pagingAdapter.Fill(pagingDS, scrollVal, 5, "Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load the records first!");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {   //When searching, the text typed will search the datagridview and reflect searched users in real time
            string con = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            string sql = "SELECT * from Users where Username like '" + txtSearch.Text + "%'";
            SqlConnection conn = new SqlConnection(con);
            pagingAdapter = new SqlDataAdapter(sql, con);
            pagingDS = new DataSet();
            conn.Open();
            pagingAdapter.Fill(pagingDS, scrollVal, 5, "Users");
            conn.Close();
            AdminGridView.DataSource = pagingDS;
            AdminGridView.DataMember = "Users";
            try
            {
                AdminGridView.ClearSelection();   //or restore rows backcolor to default
                for (int i = 0; i < (AdminGridView.Rows.Count); i++)
                {
                    if (AdminGridView.Rows[i].Cells[1].Value.ToString().StartsWith(txtSearch.Text, true, CultureInfo.InvariantCulture))
                    {
                        AdminGridView.FirstDisplayedScrollingRowIndex = i;
                        AdminGridView.Rows[i].Selected = true; //It is also possible to color the row backgroud
                        return;
                    }
                    else
                    {
                        AdminGridView.ClearSelection();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void AdminGridView_Paint(object sender, PaintEventArgs e)
        {

            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.Beige, new Rectangle(new Point(), new Size(sndr.Width, 25)));
                    // write text on top of the white rectangle just created
                    grfx.DrawString("No data returned", new Font("Arial", 12), Brushes.Black, new PointF(3, 3));
                }
            }
        }

        private void ReadOnly() //Read only method to make datagridview columns and rows read only
        {
            this.AdminGridView.Columns["UserID"].ReadOnly = true;
            this.AdminGridView.Columns["Username"].ReadOnly = true;
            this.AdminGridView.Columns["Password"].ReadOnly = true;
            this.AdminGridView.Columns["Email"].ReadOnly = true;
            this.AdminGridView.Columns["DateCreated"].ReadOnly = true;
            this.AdminGridView.Columns["LastLogin"].ReadOnly = true;
            this.AdminGridView.Columns["AccessLevel"].ReadOnly = true;
        }

        private void AdminForm_Load_2(object sender, EventArgs e)
        {
            //dateTime.Format = DateTimePickerFormat.Custom;
            //dateTime.CustomFormat = "dd-MM-yyyy";
            System.Windows.Forms.Timer TimeNow = new System.Windows.Forms.Timer();
            TimeNow.Interval = 1000;//ticks every 1 second
            TimeNow.Tick += new EventHandler(TimeNow_Tick);
            TimeNow.Start();
            DisplayData();
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            DisplayData();
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Users where DateCreated = @Date", conn);
                cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = dateTime.Value;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable db = new DataTable();
                sda.Fill(db);
                AdminGridView.DataSource = db;
                AutoClosingMessageBox.Show("Loading", "Loading", 500);
                DisplayData();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txtEmail.Focus();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtPassword.Focus();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUsername.Focus();
        }

        private void RFID() //Method to generate random RFID tags from the given tags assigned to users.
        {
            Random r1 = new Random();
            string[] RFID = new string[6];
            RFID[0] = "66006C1C63";
            RFID[1] = "66006C221E";
            RFID[2] = "6A003E3998";
            RFID[3] = "66006C1191";
            RFID[4] = "66006BFAA5";
            RFID[5] = "66006C1ECB";
        }

        private void AdminForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                MessageBox.Show("Caps Lock Key is on");
            }
            if (e.KeyCode == Keys.NumLock)
            {
                MessageBox.Show("Num Lock key is on");
            }
        }

        private void AdminGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            }

        private void AdminGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 1; i < AdminGridView.RowCount - 1; i++)
            {
                Boolean isEmpty = true;
                for (int j = 0; j < AdminGridView.Columns.Count; j++)
                {
                    if (AdminGridView.Rows[i].Cells[j].Value.ToString() != "")
                    {
                        isEmpty = false;
                        break;
                    }
                }
                if (isEmpty)
                {
                    AdminGridView.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        }
    }









