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
public class OrderHistory
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;

    //system configuration connectionstring settings_constr;
    string _connstr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private string _order_id = null;
    private string _pickupdvr = "";
    private string _deliverydvr = null;
    private string _order_status = null;
    private string _payment_info = "";
    private string _cust_id = "";
    private string _total_price = null;
    private string _todate = null;
    private string _totime = null;
    private string _frotime = null;
    private string _frodate = null;
    private string _pickupaddrid = null;
    private string _deliveryaddrid = null;
    private string _email = "";


    // Default constructor
    public OrderHistory()
    {
    }

    // Constructor that take in all data required to build a Product object
    public OrderHistory(string order_id, string pickupdvr,
                   string deliverydvr, string order_status, string payment_info, string cust_id, string total_price, string todate, string totime, string frodate, string frotime, string pickupaddrid, string deliveryaddrid, string email)
    {
        _order_id = order_id;
        _pickupdvr = pickupdvr;
        _deliverydvr = deliverydvr;
        _order_status = order_status;
        _payment_info = payment_info;
        _cust_id = cust_id;
        _total_price = total_price;
        _todate = todate;
        _totime = totime;
        _frodate = frodate;
        _frotime = frotime;
        _pickupaddrid = pickupaddrid;
        _deliveryaddrid = deliveryaddrid;
        _email = email;

    }

    public int Orderupdate(string order_id, string pickupdvr, string deliverydvr, string order_status, string payment_info, string cust_id, string total_price, string todatetime, string frodatetime)
    {
        throw new NotImplementedException();
    }

    public string order_id
    {
        get { return _order_id; }
        set { _order_id = value; }
    }

    public string pickupdvr
    {
        get { return _pickupdvr; }
        set { _pickupdvr = value; }
    }

    public int Orderupdate(string order_id, string pickupdvr, string deliverydvr, string order_status, string payment_info, string cust_id, string total_price, string todate, string totime, string frodate, string frotime, string pickupaddrid, string deliveryaddrid)
    {
        throw new NotImplementedException();
    }

    public string deliverydvr
    {
        get { return _deliverydvr; }
        set { _deliverydvr = value; }
    }
    public string order_status
    {
        get { return _order_status; }
        set { _order_status = value; }
    }
    public string payment_info
    {
        get { return _payment_info; }
        set { _payment_info = value; }
    }
    public string cust_id
    {
        get { return _cust_id; }
        set { _cust_id = value; }
    }
    public string total_price
    {
        get { return _total_price; }
        set { _total_price = value; }
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
    public string email
    {
        get { return _email; }
        set { _email = value; }
    }

    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public OrderHistory getOrder(string order)
    {
        OrderHistory orderDetail = null;

        string order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, email;

        string queryStr = "select A.cust_id, A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid, (select email from cust_info B where B.cust_id = A.cust_id) as email from laundry_order A where A.order_status =@pStatus";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@order_id", orderDetail);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //sheck if there are any resultsets
        if (dr.Read())
        {

            order_id = dr["order_id"].ToString();
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            order_status = dr["order_status"].ToString();
            payment_info = dr["payment_info"].ToString();
            cust_id = dr["cust_id"].ToString();
            total_price = dr["total_price"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            frotime = dr["frotime"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();
            email = dr["email"].ToString();

            orderDetail = new OrderHistory(order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, email);
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

    public List<OrderHistory> getOrderAll()
    {
        List<OrderHistory> orderList = new List<OrderHistory>();

        string order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, email;
        string queryStr = "select A.cust_id, A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid,(select address from address B where B.address_id = A.pickupaddrid) as pickupaddr, (select address from address C where C.address_id = A.deliveryaddrid) as deliveryaddr, (select email from cust_info D where D.cust_id = A.cust_id) as email from laundry_order A";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            order_id = dr["order_id"].ToString();
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            order_status = dr["order_status"].ToString();
            payment_info = dr["payment_info"].ToString();
            cust_id = dr["cust_id"].ToString();
            total_price = dr["total_price"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            frotime = dr["frotime"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();
            email = dr["email"].ToString();

            OrderHistory a = new OrderHistory(order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, email);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }

    public List<OrderHistory> getOrderbyStatus(string pStatus)
    {
        List<OrderHistory> orderList = new List<OrderHistory>();

        string order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, email;
        string queryStr = "select A.cust_id, A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid, (select email from cust_info B where B.cust_id = A.cust_id) as email from laundry_order A where A.order_status =@pStatus";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@pStatus", pStatus);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            order_id = dr["order_id"].ToString();
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            order_status = dr["order_status"].ToString();
            payment_info = dr["payment_info"].ToString();
            cust_id = dr["cust_id"].ToString();
            total_price = dr["total_price"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            frotime = dr["frotime"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();
            email = dr["email"].ToString();

            OrderHistory a = new OrderHistory(order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, email);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }
    public int Orderupdate(string order_id, string pickupdvr,
                   string deliverydvr, string order_status, string payment_info, string cust_id, string total_price, string todate, string totime, string frodate, string frotime, string pickupaddrid, string deliveryaddrid, string email)
    {
        string queryStr = "UPDATE laundry_order and cust_info SET" +
        " pickupdvr = @pickupdvr," +
        " deliverydvr = @deliverydvr," +
        " order_status = @order_status," +
        " payment_info = @payment_info," +
        " cust_id = @cust_id," +
        " total_price = @total_price," +
        " todate = @todate," +
        " totime = @totime," +
        " frodate  = @frodate," +
        " frotime = @frotime," +
        " pickupaddrid = @pickupaddrid," +
        " deliveryaddrid = @deliveryaddrid," +
        "email = @email" +
        " WHERE order_id = @order_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@pickupdvr", pickupdvr);
        cmd.Parameters.AddWithValue("@deliverydvr", deliverydvr);
        cmd.Parameters.AddWithValue("@order_stauts", order_status);
        cmd.Parameters.AddWithValue("@payment_info", payment_info);
        cmd.Parameters.AddWithValue("@cust_id", cust_id);
        cmd.Parameters.AddWithValue("@total_price", total_price);
        cmd.Parameters.AddWithValue("@todate", todate);
        cmd.Parameters.AddWithValue("@totime", totime);
        cmd.Parameters.AddWithValue("@frodate", frodate);
        cmd.Parameters.AddWithValue("@frotime", frotime);
        cmd.Parameters.AddWithValue("@pickupaddrid", pickupaddrid);
        cmd.Parameters.AddWithValue("@deliveryaddrid", deliveryaddrid);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@order_id", order_id);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update

    public int orderUpdateStatus(string order_id, string order_status)
    {
        string queryStr = "UPDATE laundry_order SET" +
        " order_status = @order_status" +
        " WHERE order_id = @order_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@order_status", order_status);
        cmd.Parameters.AddWithValue("@order_id", order_id);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update

    // public int orderUpdate(string orderStatus)
    //{
    //  string queryStr = "UPDATE Order SET" +
    //" Product_ID = @productID, " +
    //" order_status = @orderStatus, ";
    //      SqlConnection conn = new SqlConnection(_connstr);
    //    SqlCommand cmd = new SqlCommand(queryStr, conn);
    //  cmd.Parameters.AddWithValue("@orderStatus", orderStatus);
    //conn.Open();
    //int nofRow = 0;
    // nofRow = cmd.ExecuteNonQuery();
    // conn.Close();
    // return nofRow;
}//end Update

//}
