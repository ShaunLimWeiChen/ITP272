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

public partial class Homeguest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            Response.Redirect("Home.aspx");
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