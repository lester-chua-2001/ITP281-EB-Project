using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;using System.Configuration;

/// <summary>
/// Summary description for Items
/// </summary>
public class Items
{
    string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _item_id = 0;
    private int _order_id = 0;
    private string _item_name = null;
    private decimal _item_price = 0;
    private int _quantity = 0;
    private string _cleantype = null;

    public Items()
    {

    }
    public Items(int item_id, int order_id, string item_name, decimal item_price, int quantity, string cleantype)
    {

        _item_id = item_id;
        _order_id = order_id;
        _item_name = item_name;
        _item_price = item_price;
        _quantity = quantity;
        _cleantype = cleantype;

    }
    public Items(int order_id, string item_name, decimal item_price, int quantity, string cleantype)
        : this(0, order_id, item_name, item_price, quantity, cleantype)
    {

    }
    public int item_id
    {
        get { return _item_id; }
        set { _item_id = value; }
    }
    public int order_id
    {
        get { return _order_id; }
        set { _order_id = value; }
    }
    public string item_name
    {
        get { return _item_name; }
        set { _item_name = value; }
    }
    public decimal item_price
    {
        get { return _item_price; }
        set { _item_price = value; }
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
    public List<Items> getOrderItems(int order_id)
    {
        List<Items> orderItemList = new List<Items>();

        int item_id, quantity;
        string item_name, cleantype;
        decimal item_price;
        string queryStr = "SELECT * FROM order_items where order_id= @pid";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@pid", order_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
       
        while (dr.Read())
        {
            item_id = Convert.ToInt32(dr["item_id"].ToString());
            order_id = Convert.ToInt32(dr["order_id"].ToString());
            item_price = decimal.Parse(dr["item_price"].ToString());
            item_name = dr["item_name"].ToString();
            quantity = Convert.ToInt32(dr["quantity"].ToString()); ;
            cleantype = dr["cleantype"].ToString();

            Items b = new Items(order_id, item_id, item_name, item_price, quantity, cleantype);
            orderItemList.Add(b);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderItemList;
    }
    
}