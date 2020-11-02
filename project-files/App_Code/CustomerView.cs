using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for CustomerView
/// </summary>
public class CustomerView
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
    private string _pickupaddrid = null;
    private string _deliveryaddrid = null;
    private int _cust_id = 0;

    public CustomerView()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public CustomerView(int order_id, decimal total_price, string pickupdvr, string deliverydvr, string todate, string totime, string frodate, string frotime, string order_status, string payment_info, string pickupaddrid, string deliveryaddrid, int cust_id)
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
        _cust_id = cust_id;

    }


    public CustomerView(decimal total_price, string pickupdvr, string deliverydvr, string todate, string totime, string frodate, string frotime, string order_status, string payment_info, string pickupaddrid, string deliveryaddrid, int cust_id)
        : this(0, total_price, pickupdvr, deliverydvr, todate, totime, frodate, frotime, order_status, payment_info, pickupaddrid, deliveryaddrid, cust_id)
    {

    }
    public CustomerView(int order_id)
        : this(order_id, 0, "", "", "", "", "", "", "", "", "", "", 0)
    {
    }

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
      public int cust_id
      {
          get { return _cust_id; }
          set { _cust_id = value; }
      }

    public List<CustomerView> getOrdersAll(int cust_id)
    {
        List<CustomerView> orderList = new List<CustomerView>();
        int order_id;
        decimal total_price;
        string pickupdvr, deliverydvr, todate, totime, frodate, frotime, order_status, payment_info, pickupaddrid, deliveryaddrid;
        //   string queryStr = "select A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid,(select address from address B where B.address_id = A.pickupaddrid) as pickupaddr, (select address from address C where C.address_id = A.deliveryaddrid) as deliveryaddr from laundry_order A Order By order_id";
        string queryStr = "SELECT * FROM laundry_order WHERE cust_id = @cust_id Order By order_id desc";
     //   string queryStr = "SELECT * FROM laundry_order Order By order_id desc";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@cust_id", cust_id);
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


            CustomerView a = new CustomerView(order_id, total_price, pickupdvr, deliverydvr, todate, totime, frodate, frotime, order_status, payment_info, pickupaddrid, deliveryaddrid, cust_id);
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
}