using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace SensorFormLatestNov
{
    public partial class TemperatureForm : Form
    {
        public TemperatureForm()
        {
            InitializeComponent();
        }

        #region Shaun 151719K
        private void bindTemperature() //Display Temperature sensor table method
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Temperature WHERE Timestamp BETWEEN @timeFrom AND @timeTo AND UserID=@UserID", con))
                using (SqlCommand cmd1 = new SqlCommand("SELECT avg(cast(Temperature as float)) FROM Temperature WHERE UserID=@UserID", con))
                using (SqlCommand cmd2 = new SqlCommand("SELECT min(cast(Temperature as float)) FROM Temperature WHERE UserID=@UserID", con))
                using (SqlCommand cmd3 = new SqlCommand("SELECT max(cast(Temperature as float)) FROM Temperature WHERE UserID=@UserID", con))
                using (SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Temperature WHERE UserID=@UserID", con))
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
                        string tempavg = cmd1.ExecuteScalar().ToString();
                        string tempmin = cmd2.ExecuteScalar().ToString();
                        string tempmax = cmd3.ExecuteScalar().ToString();
                        string tempcount = cmd4.ExecuteScalar().ToString();
                        txtAvg.Text = "Total Temp Records = " + tempcount + "\n" + "Average Temp: " + Math.Round(Convert.ToDecimal(tempavg), 2).ToString() + " C "
                            + "\n" + "Lowest Temp: " + Math.Round(Convert.ToDecimal(tempmin), 2).ToString() + " C "
                            + "\n" + "Highest Temp: " + Math.Round(Convert.ToDecimal(tempmax), 2).ToString() + " C ";
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                TempGridView.DataSource = dt;
                                this.TempGridView.Columns[0].ReadOnly = true;
                                this.TempGridView.Columns[1].ReadOnly = true;
                                this.TempGridView.Columns[2].ReadOnly = true;
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

        private void FromDateTime_ValueChanged(object sender, EventArgs e)
        {
            bindTemperature();
        }

        private void ToDateTime_ValueChanged(object sender, EventArgs e)
        {
            bindTemperature();
        }

        private void TemperatureForm_Load(object sender, EventArgs e)
        {
            bindTemperature();
            txtID.Text = SensorForm.ID;
            txtUser.Text = SensorForm.Username;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (TempGridView.DataSource == null)
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
                    for (j = 0; j < TempGridView.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = TempGridView.Columns[j].HeaderText;
                    }

                    StartRow++;

                    if (TempGridView == null)
                    {
                        MessageBox.Show("No data to export");
                    }
                    else
                    {
                        //Write datagridview content
                        for (i = 0; i < TempGridView.Rows.Count; i++)
                        {
                            for (j = 0; j < TempGridView.Columns.Count; j++)
                            {
                                try
                                {
                                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                                    myRange.Value2 = TempGridView[j, i].Value == null ? "" : TempGridView[j, i].Value;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TempGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteTemperature();
            bindTemperature();
        }
        private void deleteTemperature() //delete ultrasonic sensor data
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Temperature WHERE UserID=@UserID", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        //bindTemperature();
                    }
                    bindTemperature();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message);
                }
            }
        }
    }
}
#endregion
