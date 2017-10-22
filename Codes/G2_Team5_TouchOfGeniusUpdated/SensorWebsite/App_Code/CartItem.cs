using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingCartItem
/// </summary>
public class CartItem : IEquatable<CartItem>
{
    public int Quantity { get; set; }

    private int _ItemID;
    public int Product_ID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    private string _ItemImage;

    public string Product_Image
    {
        get { return _ItemImage; }
        set { _ItemImage = value; }
    }

    private string _ItemName;
    public string Product_Name
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }

    private string _ItemDesc;
    public string Product_Desc
    {
        get { return _ItemDesc; }
        set { _ItemDesc = value; }

    }

    private decimal _ItemPrice;
    public decimal Product_Price
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
    }

    public decimal TotalPrice
    {
        get { return Product_Price * Quantity; }
    }

    public CartItem(int productID)
    {
        this.Product_ID = productID;
    }

    public CartItem(int productID, Products prod)
    {
        this.Product_ID = productID;
        this.Product_Image = prod.Product_Image;
        this.Product_Name = prod.Product_Name;
        this.Product_Desc = prod.Product_Desc;
        this.Product_Price = prod.Unit_Price; ;

    }

    public CartItem(int productID, string productImage, string productName, string productDesc, decimal productPrice)
    {
        this.Product_ID = productID;
        this.Product_Image = productImage;
        this.Product_Name = productName;
        this.Product_Desc = productDesc;
        this.Product_Price = productPrice;

    }

    public bool Equals(CartItem anItem)
    {
        return anItem.Product_ID == this.Product_ID;
    }

    //public bool Equals(ShoppingCartItem product)
    //{
    //    return product.ItemID == this.ItemID;
    //}

}