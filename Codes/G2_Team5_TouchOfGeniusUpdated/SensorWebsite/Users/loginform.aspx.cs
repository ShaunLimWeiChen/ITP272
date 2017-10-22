using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//For SqlDbType
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
//For Encrpyption 
using System.IO;
using System.Text;
using System.Security.Cryptography;

public partial class Users_loginform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checking for POSTBACK user 
        if (!IsPostBack)        
        { 
            //If username and password cookie not empty, fill textbox with 
            //cookie's stored data. 
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                string username = Request.Cookies["username"].Value;
                string password = Request.Cookies["password"].Value;
            }
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //Get User input for username and password
        string username = Request.Form["username"];
        string password = Request.Form["password"];

        //Auto-save web cookies 
        Response.Cookies["username"].Expires = DateTime.Now.AddDays(30);
        Response.Cookies["password"].Expires = DateTime.Now.AddDays(30);

        //////Data from input saved to Cookie 
        Response.Cookies["username"].Value = username;
        Response.Cookies["password"].Value = password;

        //Create SqlConnection for LOGIN 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT Username, Password, UserID, AccessLevel FROM Users WHERE Username=@username AND Password=@password", con);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", Encrypt(password));
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            cmd1.ExecuteNonQuery();

            if (dt1.Rows.Count > 0) //If datatable is filled, -->
            {
                if (dt1.Rows[0]["Username"].ToString() == username) //If username exist, -->
                {
                    if (dt1.Rows[0]["Password"].ToString() == Encrypt(password)) //If password is correct, -->
                    {
                        //Update User lastlogin
                        SqlCommand cmdLogin = new SqlCommand("UPDATE Users SET LastLogin = @LoginDate WHERE UserID=@UserID", con);
                        string id = dt1.Rows[0]["UserID"].ToString();
                        cmdLogin.Parameters.AddWithValue("@UserID", id);
                        DateTime myDateTime = DateTime.Now;
                        string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
                        cmdLogin.Parameters.AddWithValue("@LoginDate", sqlFormattedDate);

                        cmdLogin.ExecuteNonQuery();

                        //Run command to check User Accesslevel is 0 || 1 
                        //=========== REFERENCE HERE ====================
                        SqlCommand cmdAdmin = new SqlCommand("SELECT UserID, AccessLevel FROM Users WHERE UserID=@UserID", con);
                        cmdAdmin.Parameters.AddWithValue("@UserID", id);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmdAdmin); //Create object with Data from Cmd2
                        DataTable dt2 = new DataTable();                  //Create Empty DataTable 
                        da2.Fill(dt2);                                   //Initiallise DataTable with Data from da2 

                        cmdAdmin.ExecuteNonQuery();

                        if (dt2.Rows.Count > 0) //If DataTable is filled, --> 
                        {
                            //If UserID matches in DB, --> 
                            if (dt2.Rows[0]["AccessLevel"].ToString() == ("1").ToString())
                            {
                                Session.RemoveAll();
                                Session["username"] = username;
                                Response.Redirect("../SensorPanel.aspx");
                                //Redirect to AdminPage
                            }
                            else //User can only be Admin or User
                            {
                                Session.RemoveAll();
                                Session["username"] = username;
                                try
                                {
                                    string prevUrl = Request.QueryString["from"].ToString();
                                    string redirect = "loginsuccess.aspx?from=" + prevUrl;
                                    Response.Redirect(redirect, false);
                                }
                                catch (Exception ex)
                                {
                                    Response.Redirect("loginsuccess.aspx");
                                    throw ex;
                                }
                                Response.Redirect("=loginsuccess.aspx");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('Wrong Username or Password detected.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Wrong Username or Password detected.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Wrong Username or Password detected.')</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Wrong Username or Password detected.')</script>");
            }

        }
        catch 
        {
            Response.Write("<script language='javascript'>alert('An error occurered. Please try again.')</script>");
        }
        finally
        {
            con.Close();
        }
    }

    //Encryption Code for Password with AES 
    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("registerform.aspx");
    }
}