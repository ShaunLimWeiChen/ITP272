using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_successlogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        displayname.Text = Session["username"].ToString();
        Response.AddHeader("REFRESH", "3;URL=LogoutFunction.aspx");
    }
}