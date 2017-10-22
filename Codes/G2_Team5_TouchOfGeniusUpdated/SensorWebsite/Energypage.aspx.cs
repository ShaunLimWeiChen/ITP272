using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Energypage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            UpdatePanel1.Visible = true;
            UpdatePanel2.Visible = false;
            lblusername.Text = Session["Username"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString);
            con.Open();
            string getuserid = "SELECT *FROM Users WHERE Username='" + lblusername.Text + "'";
            SqlCommand cmd1 = new SqlCommand(getuserid, con);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                lblUserID.Text = reader["UserID"].ToString();
                lbllastlogin.Text = reader["LastLogin"].ToString();
            }
            con.Close();
        }
        else
        {
            Response.Redirect("Homeguest.aspx");
        }

        if (!this.IsPostBack)
        {
            if (lblusername.Text == "Username")
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Horsepower"), new DataColumn("Original Efficiency (%)"), new DataColumn("Final Efficiency (%)"), 
                new DataColumn("Monthly Energy Savings, kWh"), new DataColumn("Dollar Savings $/Month")});
                dt.Rows.Add(10, 89.5, 90.5, 50.4, 2.50);
                dt.Rows.Add(25, 92.4, 93.4, 118.3, 5.92);
                dt.Rows.Add(50, 93.0, 94.0, 233.6, 11.67);
                dt.Rows.Add(100, 94.5, 95.5, 452.6, 22.67);
                dt.Rows.Add(200, 95.0, 96.0, 895.8, 44.75);
                ViewState["dt"] = dt;
                this.BindGrid();

                chartEnergyEfficiency.Series.Add("ee");
                chartEnergyEfficiency.Series["ee"].XValueMember = "Monthly Energy Savings, kWh";
                chartEnergyEfficiency.Series["ee"].YValueMembers = "Dollar Savings $/Month";
                chartEnergyEfficiency.DataSource = dt;
                chartEnergyEfficiency.DataBind();
            }
        }
    }
    protected void BindGrid()
    {
        gvEnergyEfficiency.DataSource = ViewState["dt"] as DataTable;
        gvEnergyEfficiency.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void chartEnergyEfficiency_Load(object sender, EventArgs e)
    {
    }
    protected void TimerTime_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
    }
}