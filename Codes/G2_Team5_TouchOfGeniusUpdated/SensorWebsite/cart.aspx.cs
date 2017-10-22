using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class productpage : System.Web.UI.Page
{
    Products prod = null;
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
        if (!IsPostBack)
        {
            int prodID = Convert.ToInt32(Request.QueryString["prod"]);
            if (prodID != 0)
            {
                Products aProd = new Products();


                prod = aProd.getProduct(prodID);
                Cart.Instance.AddItem(prodID, prod);
            }
            LoadCart();
        }
        else
        {
            //Response.Buffer = true;
            //Response.Redirect("ShoppingCart.aspx");
        }

        if (Session["Username"] != null)
        {
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
    protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the currently selected row.
        GridViewRow row = gvProduct.SelectedRow;

        // Get Product ID from the selected row, which is the 
        // first row, i.e. index 0.
        string prodID = row.Cells[0].Text;

        // Redirect to next page, with the Product Id added to the URL,
        // e.g. ProductDetails.aspx?ProdID=1
        Response.Redirect("ProductDetails.aspx?prod=" + prodID);
    }
    protected void gvProduct_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            lbl_Error.Text = "Message : " + e.CommandArgument.ToString();
            int productId = Convert.ToInt32(e.CommandArgument);
            Cart.Instance.RemoveItem(productId);
            LoadCart();
        }
    }
    protected void LoadCart()
    {
        //bind the Items inside the Session/ShoppingCart Instance with the Datagrid
        gvProduct.DataSource = Cart.Instance.Items;
        gvProduct.DataBind();

        decimal total = 0.0m;
        foreach (CartItem item in Cart.Instance.Items)
        {
            total = total + item.TotalPrice;
        }
        lbl_TotalPrice.Text = total.ToString();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            foreach (GridViewRow row in gvProduct.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        int productId = Convert.ToInt32(gvProduct.DataKeys[row.RowIndex].Value);

                        //row.Cells[3] means that the quantity textbox must be in column 4.
                        int quantity = int.Parse(((TextBox)row.Cells[3].FindControl("tb_Quantity")).Text);
                        Cart.Instance.SetItemQuantity(productId, quantity);
                    }
                    catch (FormatException e1)
                    {
                        lbl_Error.Text = e1.Message.ToString();
                    }
                }
            }
            LoadCart();
        }
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        Cart.Instance.Items.Clear();
        LoadCart();
    }
    protected void btn_Checkout_Click(object sender, EventArgs e)
    {
        //string confirmValue = Request.Form["confirm_value"];
        //if (confirmValue == "Yes")
        //{
        //    if (Session["Username"] == null || Session["Username"].ToString() == "")
        //    {
        //        Response.Redirect("Userlogin.aspx?from=cart");
        //        //At the userlogin page, send the querystring to usersuccess.aspx
        //        //If Request.QueryString["from"] is = cart, then redirect to shopping cart
        //        //Else, go to homepage (or the default page when logging in normally)
        //    }
        //    else
        //    {
        //        btn_update_Click(sender, e);
        //        checkout();
        //        Server.Transfer("Checkout.aspx", false);
        //    }
        //}
        Response.Redirect("Error.aspx");
    }

    protected void checkout() //called by btn_Checkout_Click
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString);
        //Gets UserID based on session username - for SQL insertDetails
        string getUser = "SELECT UserID, Username FROM Users WHERE Username = @Username"; //cmd

        //Create Order (OrderID) by CustomerID - for SQL insertDetails
        string insertOrders = "INSERT INTO Order (UserID) VALUES (@UserID)"; //cmd1
        //Gets latest (current) OrderID from Orders table - for SQL insertDetails
        string getOrders = "SELECT TOP 1 OrderID FROM Order WHERE UserID = @UserID ORDER BY OrderID DESC"; //cmd2

        SqlCommand cmd = new SqlCommand(getUser, conn);
        //SqlCommand cmd2 = new SqlCommand(getCustomer, conn);

        SqlCommand cmd1 = new SqlCommand(insertOrders, conn);
        SqlCommand cmd2 = new SqlCommand(getOrders, conn);


        conn.Open();


        string username = Session["username"].ToString();
        cmd.Parameters.AddWithValue("@Username", username);
        
        int userID = 0;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            userID = reader.GetInt32(0);
        }
        reader.Close();

        cmd1.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID));


        cmd1.ExecuteNonQuery();


        cmd2.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID));


        cmd2.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter(cmd2);
        DataTable dt = new DataTable();
        da.Fill(dt);


        if (dt.Rows.Count > 0)
        {
            string orderID = dt.Rows[0]["OrderID"].ToString();
            cmd2.Parameters.AddWithValue("@OrderID", orderID);
            int productID;

            foreach (GridViewRow row in gvProduct.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        productID = Convert.ToInt32(gvProduct.DataKeys[row.RowIndex].Value);
                        int quantity = int.Parse(((TextBox)row.Cells[3].FindControl("tb_Quantity")).Text);
                    }
                    catch (Exception e1)
                    {
                        lbl_Error.Text = e1.Message.ToString();
                    }
                }
            }

            Server.Transfer("Checkout.aspx");
        }

        conn.Close();
    }
    protected void TimerTime_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
    }
}