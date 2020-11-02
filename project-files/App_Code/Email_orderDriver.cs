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
public class Email_orderDriver
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;

    //system configuration connectionstring settings_constr;
    string _connstr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private string _custID = null;
    private string _emailOrder = "";
    private string _custName = "";
    private string _contactNo = "";
    private string _mbrStatus = "";


    // Default constructor
    public Email_orderDriver()
    {
    }

    // Constructor that take in all data required to build a Product object
    public Email_orderDriver(string custID, string email, string custName, string contactNo, string mbrStatus)
    {
        _custID = custID;
        _emailOrder = email;
        _custName = custName;
        _contactNo = contactNo;
        _mbrStatus = mbrStatus;
    }



    // Constructor that take in all except product ID
    public Email_orderDriver(string email, string custName, string contactNo, string mbrStatus)
        : this(null, email, custName, contactNo, mbrStatus)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Email_orderDriver(string custID)
        : this(custID, "", "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string cust_id
    {
        get { return _custID; }
        set { _custID = value; }
    }
    public string email
    {
        get { return _emailOrder; }
        set { _emailOrder = value; }
    }
    public string cust_name
    {
        get { return _custName; }
        set { _custName = value; }
    }
    public string contact_no
    {
        get { return _contactNo; }
        set { _contactNo = value; }
    }
    public string mbr_status
    {
        get { return _mbrStatus; }
        set { _mbrStatus = value; }
    }

    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public Email_orderDriver getOrder(string custID)
    {
        Email_orderDriver orderDetail = null;

        string cust_name, contact_no, mbr_status;

        string queryStr = "Select * FROM cust_info WHERE cust_ID = @custID";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@custID", custID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //sheck if there are any resultsets
        if (dr.Read())
        {

            email = dr["email"].ToString();
            cust_name = dr["cust_name"].ToString();
            contact_no = dr["contact_no"].ToString();
            mbr_status = dr["mbr_status"].ToString();


            orderDetail = new Email_orderDriver(email, cust_name, contact_no, mbr_status);
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

    public List<Email_orderDriver> getOrderAll()
    {
        List<Email_orderDriver> orderList = new List<Email_orderDriver>();

        string custID, email, cust_name, contact_no, mbr_status;
        string queryStr = "SELECT * FROM cust_info Order By cust_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            custID = dr["cust_id"].ToString();
            email = dr["email"].ToString();
            cust_name = dr["cust_name"].ToString();
            contact_no = dr["contact_no"].ToString();
            mbr_status = dr["mbr_status"].ToString();

            Email_orderDriver a = new Email_orderDriver(custID, email, cust_name, contact_no, mbr_status);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }


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
