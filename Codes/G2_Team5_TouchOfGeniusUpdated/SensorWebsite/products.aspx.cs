using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class products : System.Web.UI.Page
{
    Products prod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            BindData();
        }
        if (Session["Username"] != null)
        {
            UpdatePanel2.Visible = false;
            lblusername.Text = Session["username"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString);
            con.Open();
            string getuserid = "Select * from Users Where Username='" + lblusername.Text + "'";
            SqlCommand cmd1 = new SqlCommand(getuserid, con);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                lblUserID.Text = reader["UserID"].ToString();
            }
            con.Close();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Please login to use the shopping features.')</script>");
            Response.AddHeader("REFRESH", "1;URL=/SensorWebsite/Homeguest.aspx");
        }
    }

    private void BindData()
    {
        gvProducts.DataSource = RetrieveProducts();
        gvProducts.DataBind();
    }

    public void AddToCart(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        int id = int.Parse(btn.CommandArgument);

        Products aProd = new Products();

        prod = aProd.getProduct(id);
        Cart.Instance.AddItem(id, prod);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "myconfirm", "GoToCart();", true);
    }

    private DataTable RetrieveProducts()
    {
        string connString = ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString;

        string sql = "SELECT Picture, ProductName, ProductID, UnitPrice FROM Product";

        DataSet products = new DataSet();
        //Open SQL Connection
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                ad.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal unitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"].ToString());
                    decimal finalPrice;
                    
                    finalPrice = unitPrice;

                    dt.Rows[i]["UnitPrice"] = finalPrice;
                }

                return dt;
            }
        }
    }
    protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TimerTime_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
    }
}