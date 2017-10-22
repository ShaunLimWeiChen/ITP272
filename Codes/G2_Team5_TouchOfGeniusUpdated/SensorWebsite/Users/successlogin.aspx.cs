using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_successlogin : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayUsername.Text = Session["username"].ToString();
        //try
        //{
        //    string prevurl = Request.QueryString["from"].ToString();
        //    if (prevurl == null || prevurl == "")
        //    {
        //        redirecturl = "Home.aspx"; ;
        //    }
        //    else
        //    {
        //        redirecturl = prevurl;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    redirecturl = "Home.aspx";
        //}

        Response.AddHeader("REFRESH", "3;URL=../Home.aspx");  

    }
    //protected string redirecturl
    //{
    //    get { return redirecturl; }
    //}
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("loginform.aspx");
    }
}