using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Products
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SensorDB"].ConnectionString;
    private int _prodID = 0;
    private string _prodImage = "";
    private string _prodName = string.Empty;
    private string _prodDesc = "";
    private decimal _unitPrice = 0;
    private int _stockLevel = 0;

    // Default constructor
    public Products()
    {
    }

    // Constructor that take in all data required to build a Product object
    public Products(int prodID, string prodImage, string prodName, string prodDesc,
                   decimal unitPrice, int stockLevel)
    {
        _prodID = prodID;
        _prodImage = prodImage;
        _prodName = prodName;
        _prodDesc = prodDesc;
        _unitPrice = unitPrice;
        _stockLevel = stockLevel;
    }

    // Constructor that take in all except product ID
    public Products(string prodName, string prodImage, string prodDesc,
           decimal unitPrice, int stockLevel)
        : this(0, prodImage, prodName, prodDesc, unitPrice, stockLevel)
    {
    }
    public Products(int prodID, string prodImage, string prodName, string prodDesc,
                   decimal unitPrice)
    {
        _prodID = prodID;
        _prodImage = prodImage;
        _prodName = prodName;
        _prodDesc = prodDesc;
        _unitPrice = unitPrice;
        _prodImage = prodImage;
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Products(int prodID)
        : this(prodID, "", "", "", 0.0m, 0)
    {
    }

    public int Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }
    public string Product_Desc
    {
        get { return _prodDesc; }
        set { _prodDesc = value; }
    }
    public decimal Unit_Price
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }



    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public Products getProduct(int prodID)
    {
        Products prodDetail = null;

        string prod_Name, prod_Image, prod_Desc;
        decimal unit_Price, discount_Amt;
        float discount_Percent;

        string queryStr = "SELECT * FROM Product WHERE ProductID = @ProdID";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ProdID", prodID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //Check if there are any resultsets
        if (dr.Read())
        {
            prod_Name = dr["ProductName"].ToString();
            prod_Image = dr["Picture"].ToString();
            prod_Desc = dr["ProductDescription"].ToString();
            prod_Image = dr["Picture"].ToString();
            unit_Price = decimal.Parse(dr["UnitPrice"].ToString());

            prodDetail = new Products(prodID, prod_Image, prod_Name, prod_Desc, unit_Price);
        }
        else
        {
            prodDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodDetail;

    }

    //public List<Product> getProductAll()
    //{

    //}

    //public int ProductInsert()
    //{

    //}//end Insert

    //public int ProductDelete(decimal ID)
    //{

    //}//end Delete

    //public int ProductUpdate(string pId, string pName, decimal pUnitPrice)
    //{

    //}//end Update


}