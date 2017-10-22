using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Using DB 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Smarthomelogin : System.Web.UI.Page
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
            UpdatePanel1.Visible = false;
            UpdatePanel2.Visible = true;
        }
    }
    protected void TimerTime_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
    }
}