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
//For Encryption
using System.IO;
using System.Text;
using System.Security.Cryptography;

public partial class Users_registerform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        //Get detail from form
        string username = Request.Form["username"];
        string password = Request.Form["password"];
        //string confirmpass = Request.Form["confirmpass"];
        string email = Request.Form["email"];

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString);
        {
            //Check username 
            string checkusername = "SELECT Username FROM Users WHERE Username=@username";
            string insertuser = "INSERT INTO Users (Username, Password, Email, DateCreated, LastLogin) VALUES (@username, @password, @email, @DateCreated, @Lastlogin)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.CommandText = checkusername;
            cmd.Connection = conn;
            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr != null && sdr.HasRows)
            {
                Response.Write("<script language='javascript'>alert('An error has occured.')</script>");
            }
            else
            {
                sdr.Close();
                SqlCommand con = new SqlCommand(insertuser, conn);
                con.Parameters.AddWithValue("@Username", username);
                con.Parameters.AddWithValue("@Password", Encrypt(password));
                con.Parameters.AddWithValue("@Email", email);

                //Set Date and Time to Record
                DateTime DateTimeNow = DateTime.Now;
                string formattedDate = DateTimeNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                con.Parameters.AddWithValue("@DateCreated", formattedDate);
                con.Parameters.AddWithValue("@Lastlogin", formattedDate);
                con.Parameters.AddWithValue("@AccessLevel", 0);
                con.ExecuteNonQuery();
                Response.Write("<script language='javascript'>alert('Registration Successful.')</script>");
                Response.Redirect("loginform.aspx");
            }
        }
    }

    //Encryption Code for Password
    //Using AES Encryption
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
}