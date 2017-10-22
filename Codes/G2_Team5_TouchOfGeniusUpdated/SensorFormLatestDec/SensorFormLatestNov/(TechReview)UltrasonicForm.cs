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

namespace SensorFormLatestNov
{
    public partial class UltrasonicForm : Form
    {
        public UltrasonicForm()
        {
            InitializeComponent();
        }
        public string EmptyResultText { get; set; }

        private void UltrasonicForm_Load(object sender, EventArgs e)
        {
            bindUltrasonic();
            txtID.Text = SensorForm.ID;
            txtUser.Text = SensorForm.Username;
        }
        private void bindUltrasonic() //Display Ultrasonic sensor table method
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ultrasonic WHERE Timestamp BETWEEN @timeFrom AND @timeTo AND UserID=@UserID", con))
                using (SqlCommand cmd1 = new SqlCommand("SELECT avg(cast(Distance as float)) FROM Ultrasonic WHERE UserID=@UserID", con))
                using (SqlCommand cmd2 = new SqlCommand("SELECT min(cast(Distance as float)) FROM Ultrasonic WHERE UserID=@UserID", con))
                using (SqlCommand cmd3 = new SqlCommand("SELECT max(cast(Distance as float)) FROM Ultrasonic WHERE UserID=@UserID", con))
                using (SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Ultrasonic WHERE UserID=@UserID", con))
                {
                    try
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd.Parameters.AddWithValue("@timeFrom", FromDateTime.Value);
                        cmd.Parameters.AddWithValue("@timeTo", ToDateTime.Value);
                        cmd.CommandType = CommandType.Text;
                        cmd1.CommandType = CommandType.Text;
                        cmd2.CommandType = CommandType.Text;
                        cmd3.CommandType = CommandType.Text;
                        cmd4.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd2.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd3.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd4.Parameters.AddWithValue("@UserID", txtID.Text);
                        string distavg = cmd1.ExecuteScalar().ToString();
                        string distmin = cmd2.ExecuteScalar().ToString();
                        string distmax = cmd3.ExecuteScalar().ToString();
                        string distcount = cmd4.ExecuteScalar().ToString();
                        txtAvg.Text = "Total Ultrasonic Records = " + distcount + "\n" + "Average Dist: " + Math.Round(Convert.ToDecimal(distavg), 2).ToString() + " cm "
                            + "\n" + "Lowest Dist: " + Math.Round(Convert.ToDecimal(distmin), 2).ToString() + " cm "
                            + "\n" + "Highest Dist: " + Math.Round(Convert.ToDecimal(distmax), 2).ToString() + " cm ";
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                UltraGridView.DataSource = dt;
                                this.UltraGridView.Columns[0].ReadOnly = true;
                                this.UltraGridView.Columns[1].ReadOnly = true;
                                this.UltraGridView.Columns[2].ReadOnly = true;
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (UltraGridView.DataSource == null)
                {
                    MessageBox.Show("No data to export!");
                }
                else
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    int StartCol = 1;
                    int StartRow = 1;
                    int j = 0, i = 0;

                    //Write Headers
                    for (j = 0; j < UltraGridView.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = UltraGridView.Columns[j].HeaderText;
                    }

                    StartRow++;

                    if (UltraGridView == null)
                    {
                        MessageBox.Show("No data to export");
                    }
                    else
                    {
                        //Write datagridview content
                        for (i = 0; i < UltraGridView.Rows.Count; i++)
                        {
                            for (j = 0; j < UltraGridView.Columns.Count; j++)
                            {
                                try
                                {
                                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                                    myRange.Value2 = UltraGridView[j, i].Value == null ? "" : UltraGridView[j, i].Value;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error:" + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteUltrasonic();
            bindUltrasonic();
        }
        private void deleteUltrasonic() //delete ultrasonic sensor data
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Ultrasonic WHERE UserID=@UserID", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        bindUltrasonic();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FromDateTime_ValueChanged(object sender, EventArgs e)
        {
            bindUltrasonic();
        }
        
        private void ToDateTime_ValueChanged(object sender, EventArgs e)
        {
            bindUltrasonic();
        }
    }
}
