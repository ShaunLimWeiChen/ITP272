using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Mail;

public partial class Users_forgetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnForgotPassword_Click(object sender, EventArgs e)
    {
            string username = string.Empty;
            string passwordEncrypted = string.Empty;
            string password = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["SensorDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Username, [Password] FROM Users WHERE Email = @Email"))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            username = sdr["Username"].ToString();
                            passwordEncrypted = sdr["Password"].ToString();
                            password = Decrypt(passwordEncrypted);
                        }
                    }
                    con.Close();
                }
            }
            //method to send email for password recovery
            if (!string.IsNullOrEmpty(password))
            {
                try
                {
                MailMessage mm = new MailMessage("rocketmail9797@gmail.com", txtEmail.Text.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                smtp.UseDefaultCredentials = false;
                NetworkCred.UserName = "rocketmail9797@gmail.com";
                NetworkCred.Password = "456eurrty789";
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                lblEmail.Visible = true;
                lblEmail.ForeColor = System.Drawing.Color.Green;
                lblEmail.Text = ("Password has been sent to your email address.");
               }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language= 'javascript'>alert('" + ex.Message + "')</script>");
                }
                }
            else
            {
                lblEmail.Visible = true;
                lblEmail.ForeColor = System.Drawing.Color.Red;
                lblEmail.Text = ("This email address does not match our records.");
            }
        }

      private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }