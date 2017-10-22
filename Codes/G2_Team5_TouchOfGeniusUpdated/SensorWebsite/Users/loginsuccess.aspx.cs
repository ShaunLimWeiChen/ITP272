using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginsuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        displaytext.Text = Session["username"].ToString();
        Response.AddHeader("REFRESH", "3;URL=../Home.aspx");
    }
    protected void btn2testing_Click(object sender, EventArgs e)
    {
        Response.Redirect("successlogout.aspx");
    }
}