using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SensorFormLatestNov
{
    public partial class GasForm : Form
    {
        public GasForm()
        {
            InitializeComponent();
        }

        private void GasForm_Load(object sender, EventArgs e)
        {
            BindSmoke();
        }
        private void BindSmoke()
        {
            Random r1 = new Random();
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Gas", typeof(string)),
                new DataColumn("Concentration (in ppm)", typeof(float)), new DataColumn("Timestamp", typeof(DateTime))});
            string[] Gas = new string[10];
            Gas[0] = "LPG";
            Gas[1] = "Propane";
            Gas[2] = "Methane";
            Gas[3] = "Butane";
            Gas[4] = "Octane";
            Gas[5] = "Carbon Monoxide";
            Gas[6] = "Alcohol";
            Gas[7] = "Propanol";
            Gas[8] = "Butanol";
            Gas[9] = "Formaldehyde";
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now);
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddHours(2));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddHours(2));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddMinutes(33));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddHours(62));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddDays(1));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddDays(7));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddHours(3));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddHours(7));
            dt.Rows.Add((Gas[r1.Next(Gas.Length)]), r1.Next(100, 1000), DateTime.Now.AddMonths(1));

            var average = dt.AsEnumerable().Average((row) => Convert.ToDouble(row["Concentration (in ppm)"]));
            var min = dt.AsEnumerable().Min((row) => Convert.ToDouble(row["Concentration (in ppm)"]));
            var max = dt.AsEnumerable().Max((row) => Convert.ToDouble(row["Concentration (in ppm)"]));
            var count = dt.Rows.Count;

            GasGridView.DataSource = dt;
            txtavgconc.Text = "Total Gas Records = " + count + "\n" + "Average ppm: " + Math.Round(Convert.ToDecimal(average)) + " parts per million" + "\n" + "Lowest ppm: "
                + Math.Round(Convert.ToDecimal(min)) + " parts per million" + "\n" + "Highest ppm: " + Math.Round(Convert.ToDecimal(max)) + " parts per million";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (GasGridView.DataSource == null)
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
                    for (j = 0; j < GasGridView.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = GasGridView.Columns[j].HeaderText;
                    }

                    StartRow++;

                    if (GasGridView == null)
                    {
                        MessageBox.Show("No data to export");
                    }
                    else
                    {
                        //Write datagridview content
                        for (i = 0; i < GasGridView.Rows.Count; i++)
                        {
                            for (j = 0; j < GasGridView.Columns.Count; j++)
                            {
                                try
                                {
                                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                                    myRange.Value2 = GasGridView[j, i].Value == null ? "" : GasGridView[j, i].Value;
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
    }
}
    
