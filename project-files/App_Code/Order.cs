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
public class Order
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;

    //system configuration connectionstring settings_constr;
    string _connstr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _orderID = 0;
    // this is another way to specify empty string
    private decimal _totalPrice = 0;
    private string _pickupdvr = "";
    private string _deliverydvr = "";
    private string _orderStatus;
    private string _paymentInfo;
    private string _todate;
    private string _totime;
    private string _frotime;
    private string _frodate;
    private string _pickupaddrid;
    private string _deliveryaddrid;

    // Default constructor
    public Order()
    {
    }

    // Constructor that take in all data required to build a Product object
    public Order(int orderID, string itemName, string itemID,
                   decimal totalPrice, string pickupdvr, string deliverydvr, string orderStatus, string paymentInfo, string todate, string totime, string frodate, string frotime, string pickupaddrid, string deliveryaddrid)
    {
        _orderID = orderID;
        _totalPrice = totalPrice;
        _pickupdvr = pickupdvr;
        _deliverydvr = deliverydvr;
        _orderStatus = orderStatus;
        _paymentInfo = paymentInfo;
        _todate = todate;
        _totime = totime;
        _frodate = frodate;
        _frotime = frotime;
        _pickupaddrid = pickupaddrid;
        _deliveryaddrid = deliveryaddrid;
    }

    // Constructor that take in all except product ID
    public Order(
                   decimal totalPrice, string pickupdvr, string deliverydvr, string orderStatus, string paymentInfo, string todate, string totime, string frodate, string frotime, string pickupaddrid, string deliveryaddrid)
        : this(0, totalPrice, pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Order(int orderID)
    {
        _orderID = orderID;
    }

    public Order(int orderID, decimal total_Price, string pickupdvr, string deliverydvr, string orderStatus, string paymentInfo, string todate, string totime, string frodate, string frotime, string pickupaddrid, string deliveryaddrid)
        : this(orderID)
    {
        this.total_price = total_Price;
        this.pickupdvr = pickupdvr;
        this.deliverydvr = deliverydvr;
        this.order_status = orderStatus;
        this.payment_info = paymentInfo;
        this.todate = todate;
        this.totime = totime;
        this.frodate = frodate;
        this.frotime = frotime;
        this.pickupaddrid = pickupaddrid;
        this.deliveryaddrid = deliveryaddrid;
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public int order_id
    {
        get { return _orderID; }
        set { _orderID = value; }
    }
    public decimal total_price
    {
        get { return _totalPrice; }
        set { _totalPrice = value; }
    }
    public string pickupdvr
    {
        get { return _pickupdvr; }
        set { _pickupdvr = value; }
    }
    public string deliverydvr
    {
        get { return _deliverydvr; }
        set { _deliverydvr = value; }
    }
    public string order_status
    {
        get { return _orderStatus; }
        set { _orderStatus = value; }
    }
    public string payment_info
    {
        get { return _paymentInfo; }
        set { _paymentInfo = value; }
    }
    public string todate
    {
        get { return _todate; }
        set { _todate = value; }
    }
    public string totime
    {
        get { return _totime; }
        set { _totime = value; }
    }
    public string frodate
    {
        get { return _frodate; }
        set { _frodate = value; }
    }
    public string frotime
    {
        get { return _frotime; }
        set { _frotime = value; }
    }
    public string pickupaddrid
    {
        get { return _pickupaddrid; }
        set { _pickupaddrid = value; }
    }
    public string deliveryaddrid
    {
        get { return _deliveryaddrid; }
        set { _deliveryaddrid = value; }
    }

    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public Order getOrder(int orderID)
    {
        Order orderDetail = null;

        //       string pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddr, deliveryaddr;
        string pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid;
        decimal total_Price;

        //      string queryStr = "select A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid,(select address from address B where B.address_id = A.pickupaddrid) as pickupaddr, (select address from address C where C.address_id = A.deliveryaddrid) as deliveryaddr from laundry_order A";
        string queryStr = "select * from laundry_order";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@orderID", orderID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //sheck if there are any resultsets
        if (dr.Read())
        {


            total_Price = decimal.Parse(dr["total_price"].ToString());
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            orderStatus = dr["order_status"].ToString();
            paymentInfo = dr["payment_info"].ToString();
            todate = dr["todate"].ToString();
            totime = dr["totime"].ToString();
            frodate = dr["frodate"].ToString();
            frotime = dr["frotime"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();
            //         pickupaddr = dr["pickupaddr"].ToString();
            //          deliveryaddr = dr["deliveryaddr"].ToString();
            //todatetime = DateTime.Parse(dr["todatetime"].ToString());
            //frodatetime = DateTime.Parse(dr["todatetime"].ToString());

            orderDetail = new Order(orderID, total_Price, pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid);
        }
        else
        {
            orderDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderDetail;
    }


    public List<Order> getOrderAll(string exp, string dir)
    {
        List<Order> orderList = new List<Order>();

        int orderID;
        string pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid;
        decimal total_Price;
        //  string queryStr = "select A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid,(select address from address B where B.address_id = A.pickupaddrid) as pickupaddr, (select address from address C where C.address_id = A.deliveryaddrid) as deliveryaddr from laundry_order A order by " + exp + " " + dir;
        string queryStr = "select * from laundry_order order by " + exp + " " + dir;
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            orderID = Convert.ToInt32(dr["order_id"].ToString());
            total_Price = decimal.Parse(dr["total_price"].ToString());
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            orderStatus = dr["order_status"].ToString();
            paymentInfo = dr["payment_info"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            frotime = dr["frotime"].ToString();
            //   pickupaddr = dr["pickupaddr"].ToString();
            //   deliveryaddr = dr["deliveryaddr"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();


            //DateTime todatetime = DateTime.Parse(dr["todatetime"].ToString());
            //DateTime frodatetime = DateTime.Parse(dr["todatetime"].ToString());

            Order a = new Order(orderID, total_Price, pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }

    public List<Order> filterstatus(string para)
    {
        List<Order> orderList = new List<Order>();

        int orderID;
        string pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid;
        decimal total_Price;

        string connect = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        string queryStr;
        if (para == "All")
        {
            queryStr = "select * from laundry_order";

        }
        else
        {
            queryStr = "select * from laundry_order where order_status = '" + para + "'";
        }
        /*
        SqlCommand comm = new SqlCommand(querystring, con);
        con.Open();

        SqlDataAdapter sda = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        return dt;
        */
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            orderID = Convert.ToInt32(dr["order_id"].ToString());
            total_Price = decimal.Parse(dr["total_price"].ToString());
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            orderStatus = dr["order_status"].ToString();
            paymentInfo = dr["payment_info"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            frotime = dr["frotime"].ToString();
            //pickupaddr = dr["pickupaddr"].ToString();
            //deliveryaddr = dr["deliveryaddr"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();


            //DateTime todatetime = DateTime.Parse(dr["todatetime"].ToString());
            //DateTime frodatetime = DateTime.Parse(dr["todatetime"].ToString());

            Order a = new Order(orderID, total_Price, pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }
}
