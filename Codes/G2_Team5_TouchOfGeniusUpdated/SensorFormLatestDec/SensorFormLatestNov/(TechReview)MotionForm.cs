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

namespace SensorFormLatestNov
{
    public partial class MotionForm : Form
    {
        public MotionForm()
        {
            InitializeComponent();
        }

        private void MotionForm_Load(object sender, EventArgs e)
        {
            bindMotion();
            txtID.Text = SensorForm.ID;
            txtUser.Text = SensorForm.Username;
        }
        private void bindMotion() //Display Motion sensor table method
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Motion WHERE UserID=@UserID", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            MotionGridView.DataSource = dt;
                            MotionGridView.DataSource = dt;
                            this.MotionGridView.Columns[0].ReadOnly = true;
                            this.MotionGridView.Columns[1].ReadOnly = true;
                        }
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MotionGridView.DataSource == null)
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
                    for (j = 0; j < MotionGridView.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = MotionGridView.Columns[j].HeaderText;
                    }

                    StartRow++;

                    if (MotionGridView == null)
                    {
                        MessageBox.Show("No data to export");
                    }
                    else
                    {
                        //Write datagridview content
                        for (i = 0; i < MotionGridView.Rows.Count; i++)
                        {
                            for (j = 0; j < MotionGridView.Columns.Count; j++)
                            {
                                try
                                {
                                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                                    myRange.Value2 = MotionGridView[j, i].Value == null ? "" : MotionGridView[j, i].Value;
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
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteMotion();
            bindMotion();
        }

        private void deleteMotion() //delete motion sensor data
        {
            string conn = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Motion WHERE UserID=@UserID", connection);
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@UserID", txtID.Text);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        bindMotion();
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
    }
}

