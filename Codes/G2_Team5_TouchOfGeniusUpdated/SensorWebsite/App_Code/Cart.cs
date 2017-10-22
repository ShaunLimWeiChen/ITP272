using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Cart
{
    public List<CartItem> Items { get; private set; }

    //public static readonly ShoppingCart Instance;
    public static Cart Instance;

    // A Static Default ShoppingCart Constructor. Meaning developers need not use the New keyword.
    static Cart()
    {
        if (HttpContext.Current.Session["CSharpShoppingCart"] == null)
        {
            Instance = new Cart();
            Instance.Items = new List<CartItem>();
            HttpContext.Current.Session["CSharpShoppingCart"] = Instance;
        }
        else
        {
            Instance = (Cart)HttpContext.Current.Session["CSharpShoppingCart"];
        }
    }

    // A Default ShoppingCart Constructor. 
    protected Cart() { }

    // Find a ShoppingCartItem inside the ShoppingCart Instance by providing a Product ID
    public CartItem getAShoppingCartItem(int ProductID)
    {

        //ShoppingCartItem newItem = new ShoppingCartItem(ProductID, prod);

        if (!Items.Equals(null))
        {
            foreach (CartItem item in Items)
            {
                if (item.Product_ID == ProductID)
                {
                    return item;
                }
            }
        }
        return null;
    }

    // Add a ShoppingCartItem into the ShoppingCart Instance by providing a Product ID and Product object
    public void AddItem(int ProductID, Products prod)
    {
        //ShoppingCartItem newItem = new ShoppingCartItem(ProductID);
        CartItem newItem = new CartItem(ProductID, prod);

        if (Items.Contains(newItem))
        {
            foreach (CartItem item in Items)
            {
                if (item.Equals(newItem))
                {
                    item.Quantity++;
                    return;
                }
            }
        }
        else
        {
            newItem.Quantity = 1;
            Items.Add(newItem);
        }
    }

    public void SetItemQuantity(int ProductID, int quantity)
    {
        if (quantity == 0)
        {
            RemoveItem(ProductID);
            return;
        }

        CartItem updatedItem = new CartItem(ProductID);

        foreach (CartItem Item in Items)
        {
            if (Item.Equals(updatedItem))
            {
                Item.Quantity = quantity;
                return;
            }
        }
    }

    // Remove a ShoppingCartItem from the ShoppingCart Instance by providing a Product ID 
    public void RemoveItem(int ProductID)
    {
        Items.Remove(Cart.Instance.getAShoppingCartItem(ProductID));
    }

    public void ResetCart()
    {
        Items.Clear();
    }

    public decimal GetSubTotal()
    {
        decimal subTotal = 0;
        foreach (CartItem item in Items)
        {
            subTotal += item.TotalPrice;
        }
        return subTotal;
    }
}