using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class Orders
{
    static string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _order_id = 0;
    private decimal _total_price = 0;
    private string _pickupdvr = null;
    private string _deliverydvr = null;
    private string _todate = null;
    private string _totime = null;
    private string _frodate = null;
    private string _frotime = null;
    private string _order_status = null;
    private string _payment_info = null;
    //   private string _pickupaddrid = null;
    private string _pickupaddrid = null;
    //   private string _deliveryaddrid = null;
    private string _deliveryaddrid = null;



    public Orders()
    {

    }

    public Orders(int order_id, decimal total_price, string pickupdvr, string deliverydvr, string todate, string totime, string frodate, string frotime, string order_status, string payment_info, string pickupaddrid, string deliveryaddrid)
    {
        _order_id = order_id;
        _total_price = total_price;
        _pickupdvr = pickupdvr;
        _deliverydvr = deliverydvr;
        _todate = todate;
        _totime = totime;
        _frodate = frodate;
        _frotime = frotime;
        _order_status = order_status;
        _payment_info = payment_info;
        //     _deliveryaddrid = deliveryaddrid;
        _deliveryaddrid = deliveryaddrid;
        //      _pickupaddrid = pickupaddrid;
        _pickupaddrid = pickupaddrid;

    }


    public Orders(decimal total_price, string pickupdvr, string deliverydvr, string todate, string totime, string frodate, string frotime, string order_status, string payment_info, string pickupaddrid, string deliveryaddrid)
        : this(0, total_price, pickupdvr, deliverydvr, todate, totime, frodate, frotime, order_status, payment_info, pickupaddrid, deliveryaddrid)
    {

    }
    //    public Orders(int order_id)
    //   {
    //        _order_id = order_id;
    //    }

    //    public Orders(int order_id, decimal total_price, string pickupdvr, string deliverydvr, string order_status, string payment_info, string todate, string totime, string frodate, string frotime, string pickupaddr, string deliveryaddr) 
    //       : this(order_id)
    //    {
    //        this.total_price = total_price;
    //       this.pickupdvr = pickupdvr;
    //        this.deliverydvr = deliverydvr;
    //       this.order_status = order_status;
    //        this.payment_info = payment_info;
    //       this.todate = todate;
    //       this.totime = totime;
    //       this.frodate = frodate;
    //       this.frotime = frotime;
    //       this.pickupaddr = pickupaddr;
    //        this.deliveryaddr = deliveryaddr;
    //    }

    public int order_id
    {
        get { return _order_id; }
        set { _order_id = value; }
    }

    public decimal total_price
    {
        get { return _total_price; }
        set { _total_price = value; }
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

    public List<Orders> getOrdersAll()
    {
        List<Orders> orderList = new List<Orders>();
        int order_id;
        decimal total_price;
        string pickupdvr, deliverydvr, todate, totime, frodate, frotime, order_status, payment_info, pickupaddrid, deliveryaddrid;
        //   string queryStr = "select A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid,(select address from address B where B.address_id = A.pickupaddrid) as pickupaddr, (select address from address C where C.address_id = A.deliveryaddrid) as deliveryaddr from laundry_order A Order By order_id";
        string queryStr = "SELECT * FROM laundry_order Order By order_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            order_id = Convert.ToInt32(dr["order_id"].ToString());

            total_price = decimal.Parse(dr["total_price"].ToString());
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            //    todate = dr["todate"].ToString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            //   frodate = dr["frodate"].ToString();
            frotime = dr["frotime"].ToString();
            order_status = dr["order_status"].ToString();
            payment_info = dr["payment_info"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();

            Orders a = new Orders(order_id, total_price, pickupdvr, deliverydvr, todate, totime, frodate, frotime, order_status, payment_info, pickupaddrid, deliveryaddrid);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }


    public int OrderDelete(string ID)
    {
        string queryStr = "DELETE FROM laundry_order WHERE order_id=@ID";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }


    public static int OrderInsert(Orders order, string cust_id)
    {
        int result = 0;
        string queryStr = "INSERT INTO laundry_order(order_id, total_price, pickupdvr, deliverydvr, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid, order_status, payment_info, cust_id) values (@order_id, @total_price, @pickupdvr, @deliverydvr, @todate, @totime, @frodate, @frotime, @pickupaddrid, @deliveryaddrid, @order_status, @payment_info, @cust_id)";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@order_id", order.order_id);
        cmd.Parameters.AddWithValue("@total_price", order.total_price);
        cmd.Parameters.AddWithValue("@pickupdvr", order.pickupdvr);
        cmd.Parameters.AddWithValue("@deliverydvr", order.deliverydvr);
        cmd.Parameters.AddWithValue("@todate", DateTime.ParseExact(order.todate, "dd/MM/yyyy", null));
        cmd.Parameters.AddWithValue("@totime", order.totime);
        cmd.Parameters.AddWithValue("@frodate", DateTime.ParseExact(order.frodate, "dd/MM/yyyy", null));
        cmd.Parameters.AddWithValue("@frotime", order.frotime);
        cmd.Parameters.AddWithValue("@order_status", order.order_status);
        cmd.Parameters.AddWithValue("@payment_info", order.payment_info);
        cmd.Parameters.AddWithValue("@cust_id", cust_id);
        cmd.Parameters.AddWithValue("@pickupaddrid", order.pickupaddrid);
        cmd.Parameters.AddWithValue("@deliveryaddrid", order.deliveryaddrid);
        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();
        return result;
    }

    public static int getNewOrderId()
    {
        int order_id = 0;
        string queryStr = "SELECT TOP 1 order_id FROM laundry_order ORDER BY order_id DESC";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            order_id = Convert.ToInt32(dr["order_id"]);
        }
        conn.Close();
        return order_id + 5;
    }
}


