using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Product
/// </summary>
public class View
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;

    //system configuration connectionstring settings_constr;
    string _connstr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _itemID = 0;
    private string _itemName;
    private decimal _itemPrice = 0;
    private int _quantity = 0;
    private string _cleantype;
    private int _orderID = 0;

    // Default constructor
    public View()
    {
    }

    // Constructor that take in all data required to build a Product object
    public View(int itemID, string itemName, decimal itemPrice, int quantity,
                   string cleantype, int orderID)
    {
        _itemID = itemID;
        _itemName = itemName;
        _itemPrice = itemPrice;
        _quantity = quantity;
        _cleantype = cleantype;
        _orderID = orderID;

    }

    // Constructor that take in all except product ID
    public View(string itemName, decimal itemPrice, int quantity, string cleantype, int orderID)
        : this(0, itemName, 0, 0, cleantype, 0)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public View(int itemID)
        : this(itemID, "", 0, 0, "", 0)
    {
    }


    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public int order_id
    {
        get { return _orderID; }
        set { _orderID = value; }
    }
    public int item_id
    {
        get { return _itemID; }
        set { _itemID = value; }
    }
    public string item_name
    {
        get { return _itemName; }
        set { _itemName = value; }
    }
    public decimal item_price
    {
        get { return _itemPrice; }
        set { _itemPrice = value; }
    }
    public int quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
    public string cleantype
    {
        get { return _cleantype; }
        set { _cleantype = value; }
    }

    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public View getOrder(int itemID)
    {
        View ViewDetail = null;

        int quantity, orderID;
        string itemName, cleantype;
        decimal item_Price;
        

        string queryStr = "Select * FROM order WHERE itemID = @itemID";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@itemID", itemID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //sheck if there are any resultsets
        if (dr.Read())
        {
            
            
            item_Price = decimal.Parse(dr["item_price"].ToString());
            itemName = dr["item_name"].ToString();
            quantity = Convert.ToInt32(dr["quantity"].ToString());
            cleantype = dr["cleantype"].ToString();
            orderID = Convert.ToInt32(dr["order_id"].ToString());

            ViewDetail = new View(itemID, itemName, item_Price, quantity, cleantype, orderID);
        }
        else
        {
            ViewDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return ViewDetail;
    }

    public List<View> getOrderAll()
    {
        List<View> ViewList = new List<View>();

        int itemID, quantity, orderID;
        string  item_name,cleantype;
        decimal item_Price;
        string queryStr = "SELECT * FROM order_items Order By order_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            itemID = Convert.ToInt32(dr["item_id"].ToString());
            orderID = Convert.ToInt32(dr["order_id"].ToString());
            item_Price = decimal.Parse(dr["item_price"].ToString());
            item_name = dr["item_name"].ToString();
            quantity =  Convert.ToInt32(dr["quantity"].ToString()); ;
            cleantype = dr["cleantype"].ToString();

            View a = new View(itemID, item_name, item_Price, quantity, cleantype, orderID);
            ViewList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return ViewList;
    }

    public List<View> getOrderById(int order_id)
    {
        List<View> ViewList = new List<View>();

        int itemID, quantity, orderID;
        string item_name, cleantype;
        decimal item_Price;
        string queryStr = "SELECT * FROM order_items where order_id= @pid";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@pid", order_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            itemID = Convert.ToInt32(dr["item_id"].ToString());
            orderID = Convert.ToInt32(dr["order_id"].ToString());
            item_Price = decimal.Parse(dr["item_price"].ToString());
            item_name = dr["item_name"].ToString();
            quantity = Convert.ToInt32(dr["quantity"].ToString()); ;
            cleantype = dr["cleantype"].ToString();

            View a = new View(itemID, item_name, item_Price, quantity, cleantype, orderID);
            ViewList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return ViewList;
    }
}
